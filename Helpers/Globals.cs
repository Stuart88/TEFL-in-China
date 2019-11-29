namespace TEFL_App.Helpers
{
    public static class Globals
    {
        #region Public Fields

        public const string baseURL = "https://echinacareers.com/TEFLApp/";

        public const int QuizScorePassMark = 70;
        public const int CourseExpiryTime = 6; //months

        #endregion Public Fields

        #region Public Methods

        public static string GeneralURL(string action, string searchTerms) => string.Format("{0}{1}?{2}", baseURL, action, searchTerms);

        public static string ListURL(string listType, int page, int amount, string searchTerms) => string.Format("{0}{1}?page={2}&amount={3}&{4}", baseURL, listType, page, amount, searchTerms);

        #endregion Public Methods
    }
}