using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        #region Public Fields

        public double Score = 0d;

        #endregion Public Fields

        #region Private Fields

        private static Random rnd = new Random();
        private ModuleNumber ModuleNumber;
        private List<TestQuestion> Questions;

        #endregion Private Fields

        #region Public Constructors

        public QuizPage(List<TestQuestion> questions, ModuleNumber module)
        {
            Questions = Shuffle(questions);
            IsModuleQuiz = module != ModuleNumber.FinalExam;
            IsFinalExam = module == ModuleNumber.FinalExam;
            ModuleNumber = module;
            CanDoQuiz = CheckCanDoQuiz(App.StudentProfile, module);
            CannotDoQuiz = !CanDoQuiz;
            IsManager = App.UserType == Enums.UserType.Manager;

            InitializeComponent();

            string quizTitle = module switch
            {
                ModuleNumber.Mod1 => "Module 1 Quiz",
                ModuleNumber.Mod2 => "Module 2 Quiz",
                ModuleNumber.Mod3 => "Module 3 Quiz",
                ModuleNumber.Mod4 => "Module 4 Quiz",
                ModuleNumber.FinalExam => "Final Exam",
                _ => ""
            };
            this.Title = quizTitle;
            QuizTitle.Text = quizTitle;

            PassMarkSpan.Inlines.Add(Globals.QuizScorePassMark.ToString());

            int bestAttempt = module switch
            {
                ModuleNumber.Mod1 => Functions.HighestExamScore(App.StudentProfile?.Mod1QuizScores ?? ""),
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

            if (CanDoQuiz)
            {
                CreateQuestions(Questions);
            }
            else
            {
                CannotDoQuizText.Inlines.Add(string.Format("Please first complete Module {0}", (int)module));
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public bool CanDoQuiz { get; set; }
        public bool CannotDoQuiz { get; set; }
        public bool IsFinalExam { get; set; }
        public bool IsModuleQuiz { get; set; }
        public bool IsManager { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static List<TestQuestion> Shuffle(List<TestQuestion> items)
        {
            return items.Select(x => new { value = x, order = rnd.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Adds final row to the given question grid, which will hold text showing "Correct"/"Incorrect" after quiz is comlete
        /// </summary>
        /// <param name="questionNum"></param>
        /// <param name="grid"></param>
        /// <param name="rowTag">Tag is used later for appending result text, i.e. Grid.SetRow(resultText, tag) , in QuizSubmitBtn_Click()</param>
        private void AppendResultRow(int questionNum, ref Grid grid, int rowTag)
        {
            //Add final empty row for showing question result after completion
            string rowName = string.Format("Question{0}ResultRow", questionNum);
            RowDefinition newRow = new RowDefinition
            {
                Name = rowName,
                Tag = rowTag
            };
            grid.RowDefinitions.Add(newRow);
            RegisterName(rowName, newRow);
        }

        private bool CheckCanDoQuiz(Models.TEFLProfile profile, ModuleNumber module)
        {
            return module switch
            {
                ModuleNumber.Mod1 => true,
                ModuleNumber.Mod2 => Functions.HighestExamScore(profile.Mod1QuizScores) >= Globals.QuizScorePassMark,
                ModuleNumber.Mod3 => Functions.HighestExamScore(profile.Mod2QuizScores) >= Globals.QuizScorePassMark,
                ModuleNumber.Mod4 => Functions.HighestExamScore(profile.Mod3QuizScores) >= Globals.QuizScorePassMark,
                ModuleNumber.FinalExam => Functions.HighestExamScore(profile.Mod4QuizScores) >= Globals.QuizScorePassMark,
                _ => false
            };
        }

        /// <summary>
        /// Appends a new grid of checkbox options to the referenced grid
        /// </summary>
        private void CreateCheckBoxOptions(TestQuestion question, ref Grid parent, int questionNum)
        {
            Grid grid = new Grid();

            List<MultipleChoiceOption> answers = question.Answers;

            for (int j = 0; j < answers.Count; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition { });
                string questionText = answers[j].Text;

                CheckBox checkBox = new CheckBox
                {
                    Name = string.Format("Q{0}Opt{1}", questionNum, j),
                    Content = new TextBlock { Text = questionText, Style = FindResource("AnswerOptionTextStyle") as Style },
                    Style = FindResource("CheckboxOptionStyle") as Style,
                    Tag = question.CorrectAnswers.Any(x => x == questionText)        //Tag = true if this option is a correct answer
                };
                checkBox.Checked += (s, e) =>
                {
                    Questions[questionNum].SelectedAnswers.Add(questionText);
                };
                checkBox.Unchecked += (s, e) =>
                {
                    Questions[questionNum].SelectedAnswers.Remove(questionText);
                };

                grid.Children.Add(checkBox);
                Grid.SetRow(checkBox, j);

                if (j == answers.Count - 1)
                {
                    AppendResultRow(questionNum, ref grid, j + 1);
                }
            }

            parent.Children.Add(grid);
            Grid.SetRow(grid, 1);
        }

        private void CreateQuestions(List<TestQuestion> questions)
        {
            QuestionsGrid.Children.Clear();

            for (int i = 0; i < questions.Count; i++)
            {
                //Main quiz area, holds all questions.
                QuestionsGrid.RowDefinitions.Add(new RowDefinition { Style = FindResource("QuizRowAreaStyle") as Style });

                //Single question grid. Holds question wording and answer options
                string gridName = string.Format("Question{0}Grid", i);
                Grid qGrid = new Grid()
                {
                    Name = gridName,
                    Tag = questions[i],
                    Style = FindResource("QuizQuestionAreaStyle") as Style,
                };
                RegisterName(gridName, qGrid);

                TextBlock qText = new TextBlock
                {
                    Text = string.Format("{0}. {1}", i + 1, questions[i].Question),
                    Style = FindResource("QuizQuestionWordingStyle") as Style,
                };

                qGrid.RowDefinitions.Add(new RowDefinition { Style = FindResource("QuizRowAreaStyle") as Style });
                qGrid.Children.Add(qText);
                Grid.SetRow(qText, 0);

                if (questions[i].Type == QuestionType.SingleChoice)
                {
                    CreateRadioOptions(questions[i], ref qGrid, i);
                }
                else
                {
                    CreateCheckBoxOptions(questions[i], ref qGrid, i);
                }

                qGrid.RowDefinitions.Add(new RowDefinition { Style = FindResource("QuizRowAreaStyle") as Style });
                QuestionsGrid.Children.Add(qGrid);
                Grid.SetRow(qGrid, i);
            }
        }

        /// <summary>
        /// Appends a new grid of radio button options to the referenced grid
        /// </summary>
        private void CreateRadioOptions(TestQuestion question, ref Grid parent, int questionNum)
        {
            Grid grid = new Grid();

            List<MultipleChoiceOption> answers = question.Answers;

            for (int j = 0; j < answers.Count; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition { });
                string questionText = answers[j].Text;

                RadioButton radioButton = new RadioButton
                {
                    GroupName = string.Format("Question{0}", questionNum),
                    Content = new TextBlock { Text = questionText, Style = FindResource("AnswerOptionTextStyle") as Style },
                    Style = FindResource("RadioOptionStyle") as Style,
                    Tag = question.CorrectAnswers.Any(x => x == questionText)        //Tag = true if this option is a correct answer
                };
                radioButton.Checked += (s, e) =>
                {
                    Questions[questionNum].SelectedAnswers.Add(questionText);
                };
                radioButton.Unchecked += (s, e) =>
                {
                    Questions[questionNum].SelectedAnswers.Remove(questionText);
                };

                grid.Children.Add(radioButton);
                Grid.SetRow(radioButton, j);

                if (j == answers.Count - 1)
                {
                    AppendResultRow(questionNum, ref grid, j + 1);
                }
            }

            parent.Children.Add(grid);
            Grid.SetRow(grid, 1);
        }

        private async System.Threading.Tasks.Task PostQuizResultAsync(string scoreString)
        {
            switch (ModuleNumber)
            {
                case ModuleNumber.Mod1:
                    App.StudentProfile.Mod1QuizScores += scoreString;
                    break;

                case ModuleNumber.Mod2:
                    App.StudentProfile.Mod2QuizScores += scoreString;
                    break;

                case ModuleNumber.Mod3:
                    App.StudentProfile.Mod3QuizScores += scoreString;
                    break;

                case ModuleNumber.Mod4:
                    App.StudentProfile.Mod4QuizScores += scoreString;
                    break;

                case ModuleNumber.FinalExam:
                    App.StudentProfile.ExamScores += scoreString;
                    App.StudentProfile.ExamAttempts += 1;
                    break;
            }

            var dictionary = App.StudentProfile.ConvertToDict();
            dictionary.Add("userType", "TEFLStudent");

            string userData = Functions.Base64Encode(string.Format("{0};{1}:{2}", App.ManagerProfile.ID, App.UserLogin, App.UserPassword));
            App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

            var postResult = await Functions.PostItem<Models.TEFLProfile>("EditUpdateTEFLProfile", dictionary);

            if (postResult.ok)
            {
                App.StudentProfile = postResult.data;

                Functions.ShowMessageDialog("Your score", string.Format("You scored {0}%", Score));
            }
            else
            {
                //error message shows in PostItem<>()
                // Functions.ShowErrorMessageDialog(new Exception(postResult.message));
            }
        }

        private async void QuizSubmitBtn_ClickAsync(object sender, RoutedEventArgs e)
        {
            double correct = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                //Get question grid
                Grid qGrid = (Grid)FindName(string.Format("Question{0}Grid", i));

                //Disable questions and quiz button.
                qGrid.IsEnabled = false;
                qGrid.Opacity = 0.5;
                qGrid.Background = FindResource("LightGrey") as SolidColorBrush;
                QuizSubmitBtn.IsEnabled = false;
                QuizSubmitBtn.Opacity = 0.5;

                //Add new row for showing result.
                qGrid.RowDefinitions.Add(new RowDefinition { });
                int resultRowIndex = (int)(FindName(string.Format("Question{0}ResultRow", i)) as RowDefinition).Tag;
                TextBlock resultText = new TextBlock
                {
                    Style = FindResource("ResultTextStyle") as Style
                };
                qGrid.Children.Add(resultText);
                Grid.SetRow(resultText, resultRowIndex);

                //Check answer
                if (Questions[i].SelectedAnswers.All(x => Questions[i].CorrectAnswers.Contains(x))
                    && Questions[i].CorrectAnswers.Count == Questions[i].SelectedAnswers.Count)    // compare with .Count() to make sure multiple choice answers only pass when ALL choices are correct
                {
                    correct++;
                    resultText.Text = "✔ - Correct";
                    resultText.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    resultText.Text = "❌ - Incorrect";
                    resultText.Foreground = new SolidColorBrush(Colors.Red);
                }
            }

            Score = Math.Round(100 * correct / Questions.Count, 0);

            if(App.UserType == Enums.UserType.Candidate)
            {
                await PostQuizResultAsync(Score.ToString() + ",");
            }
            else
            {
                Functions.ShowMessageDialog("Your score", string.Format("You scored {0}%", Score));
            }
        }

        #endregion Private Methods
    }
}