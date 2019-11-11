using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TEFL_App.Helpers;

namespace TEFL_App.Views.Course
{
    /// <summary>
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {
        #region Private Fields

        public bool isFinalExam;
        public bool isModuleQuiz;
        private static Random rnd = new Random();
        private List<TestQuestion> Questions;

        #endregion Private Fields

        #region Public Constructors

        public QuizPage(List<TestQuestion> questions, ModuleNumber module)
        {
            Questions = Shuffle(questions);
            isModuleQuiz = module != ModuleNumber.FinalExam;
            isFinalExam = module == ModuleNumber.FinalExam;

            InitializeComponent();

            QuizTitle.Text = module switch
            {
                ModuleNumber.Mod1 => "Module 1 Quiz",
                ModuleNumber.Mod2 => "Module 2 Quiz",
                ModuleNumber.Mod3 => "Module 3 Quiz",
                ModuleNumber.Mod4 => "Module 4 Quiz",
                ModuleNumber.FinalExam => "Final Exam",
                _ => ""
            };

            PassMarkSpan.Inlines.Add(Globals.QuizScorePassMark.ToString());

            int bestAttempt = module switch
            {
                ModuleNumber.Mod1 => Functions.HighestExamScore(App.StudentProfile?.Mod2QuizScores ?? ""),
                ModuleNumber.Mod2 => Functions.HighestExamScore(App.StudentProfile?.Mod2QuizScores ?? ""),
                ModuleNumber.Mod3 => Functions.HighestExamScore(App.StudentProfile?.Mod3QuizScores ?? ""),
                ModuleNumber.Mod4 => Functions.HighestExamScore(App.StudentProfile?.Mod4QuizScores ?? ""),
                ModuleNumber.FinalExam => Functions.HighestExamScore(App.StudentProfile?.ExamScores ?? ""),
                _ => 0
            };

            if (bestAttempt >= Globals.QuizScorePassMark)
            {
                BestAttemptSpan.Inlines.Add(string.Format("{0}% - PASSED ✔", bestAttempt));
                BestAttemptSpan.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                BestAttemptSpan.Inlines.Add(string.Format("{0}%", bestAttempt));
            }

            CreateQuestions(Questions);
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Appends a new grid of checkbox options to the referenced grid
        /// </summary>
        private void CreateCheckBoxOptions(List<MultipleChoiceOption> answers, ref Grid parent, int questionNum)
        {
            Grid grid = new Grid();

            for (int j = 0; j < answers.Count; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition { });

                CheckBox checkBox = new CheckBox
                {
                    Name = string.Format("Q{0}Opt{1}", questionNum, j),
                    Content = new TextBlock { Text = answers[j].Text, Style = FindResource("AnswerOptionTextStyle") as Style },
                    Style = FindResource("CheckboxOptionStyle") as Style
                };

                grid.Children.Add(checkBox);
                Grid.SetRow(checkBox, j);
            }

            parent.Children.Add(grid);
            Grid.SetRow(grid, 1);
        }

        private void CreateQuestions(List<TestQuestion> questions)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                //Main quiz area, holds all questions.
                QuestionsGrid.RowDefinitions.Add(new RowDefinition { Style = FindResource("QuizRowAreaStyle") as Style });

                //Single question grid. Holds question wording and answer options
                Grid qGrid = new Grid()
                {
                    Style = FindResource("QuizQuestionAreaStyle") as Style,
                };
                TextBlock qText = new TextBlock
                {
                    Text = string.Format("{0}. {1}", i + 1, questions[i].Question),
                    Style = FindResource("QuizQuestionWordingStyle") as Style
                };

                qGrid.RowDefinitions.Add(new RowDefinition { Style = FindResource("QuizRowAreaStyle") as Style });
                qGrid.Children.Add(qText);
                Grid.SetRow(qText, 0);

                if (questions[i].Type == QuestionType.SingleChoice)
                {
                    CreateRadioOptions(questions[i].Answers, ref qGrid, i);
                }
                else
                {
                    CreateCheckBoxOptions(questions[i].Answers, ref qGrid, i);
                }

                qGrid.RowDefinitions.Add(new RowDefinition { Style = FindResource("QuizRowAreaStyle") as Style });
                QuestionsGrid.Children.Add(qGrid);
                Grid.SetRow(qGrid, i);
            }
        }

        /// <summary>
        /// Appends a new grid of radio button options to the referenced grid
        /// </summary>
        private void CreateRadioOptions(List<MultipleChoiceOption> answers, ref Grid parent, int questionNum)
        {
            Grid grid = new Grid();

            for (int j = 0; j < answers.Count; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition { });

                RadioButton radioButton = new RadioButton
                {
                    GroupName = string.Format("Question{0}", questionNum),
                    Content = new TextBlock { Text = answers[j].Text, Style = FindResource("AnswerOptionTextStyle") as Style },
                    Style = FindResource("RadioOptionStyle") as Style
                };

                grid.Children.Add(radioButton);
                Grid.SetRow(radioButton, j);
            }

            parent.Children.Add(grid);
            Grid.SetRow(grid, 1);
        }

        #endregion Private Methods

        #region Public Methods

        public static List<TestQuestion> Shuffle(List<TestQuestion> items)
        {
            return items.Select(x => new { value = x, order = rnd.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();
        }

        #endregion Public Methods
    }
}