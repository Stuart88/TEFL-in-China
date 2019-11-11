using System.Collections.Generic;

namespace TEFL_App.Helpers
{
    public enum ModuleNumber
    {
        Mod1,
        Mod2,
        Mod3,
        Mod4,
        FinalExam
    }

    public enum QuestionResult
    {
        None,
        Correct,
        Wrong
    }

    public enum QuestionType
    {
        MultipleChoice,
        SingleChoice,
    }

    public class MultipleChoiceOption
    {
        #region Public Constructors

        public MultipleChoiceOption(string text)
        {
            Text = text;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Selected { get; set; }
        public string Text { get; set; }

        #endregion Public Properties
    }

    public class TeflTest
    {
        #region Public Constructors

        public TeflTest(int teflID, List<TestQuestion> questions, double score, string candName)
        {
            TEFLprofileID = teflID;
            Questions = questions;
            ModuleNumber = questions[0].Module;
            Score = score;
            CandidateName = candName;
        }

        #endregion Public Constructors

        #region Public Properties

        public string CandidateName { get; set; }
        public ModuleNumber ModuleNumber { get; set; }
        public List<TestQuestion> Questions { get; set; } = new List<TestQuestion>();
        public double Score { get; set; }
        public int TEFLprofileID { get; set; }

        #endregion Public Properties
    }

    public class TestQuestion
    {
        #region Public Constructors

        public TestQuestion(ModuleNumber module, QuestionType type, string question, List<string> answers, List<int> correctAnsIndex)
        {
            Type = type;
            Module = module;
            Question = question;

            for (int i = 0; i < answers.Count; i++)
            {
                Answers.Add(new MultipleChoiceOption(answers[i]));
            }
            for (int i = 0; i < correctAnsIndex.Count; i++)
            {
                CorrectAnswers.Add(this.Answers[correctAnsIndex[i]].Text);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public List<MultipleChoiceOption> Answers { get; set; } = new List<MultipleChoiceOption>();
        public List<string> CorrectAnswers { get; set; } = new List<string>();
        public QuestionResult FinalResult { get; set; }
        public ModuleNumber Module { get; set; }
        public string Question { get; set; }
        public QuestionType Type { get; set; }

        #endregion Public Properties
    }


}