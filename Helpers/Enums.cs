namespace TEFL_App.Helpers
{
    public static class Enums
    {
        #region Public Classes

        public static class Language
        {
            #region Public Fields

            public const string Chinese = "zh-CN";
            public const string English = "en-GB";

            #endregion Public Fields
        }

        public enum UserType
        {
            Manager,
            Candidate
        }

        public enum ModuleNum
        {
            Mod1,
            Mod2,
            Mod3,
            Mod4,
            FinalExam,
            Assignment
        }

        #endregion Public Classes
    }
}