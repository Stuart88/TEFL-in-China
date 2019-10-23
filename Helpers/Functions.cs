using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace TEFL_App.Helpers
{
    public static class Functions
    {
        #region Public Methods

        public static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = Encoding.GetEncoding("iso-8859-1").GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string ErrorMessage(Exception e)
        {
            return e.Message
                + (e.InnerException != null ? e.InnerException.Message : "")
                + (e.InnerException != null && e.InnerException.InnerException != null ? e.InnerException.InnerException.Message : "");
        }

        public static bool PassedQuiz(string scoresString)
        {
            if (string.IsNullOrEmpty(scoresString))
                return false;
            else
                return scoresString.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(s => int.Parse(s)).ToList().Max() >= Globals.QuizScorePassMark;
        }

        public static void ShowErrorMessageDialog(Exception e)
        {
            _ = MessageBox.Show(ErrorMessage(e), "Error", MessageBoxButton.OK);
        }

        public static void ShowMessageDialog(string title, string message)
        {
            _ = MessageBox.Show(message, title, MessageBoxButton.OK);
        }

        #endregion Public Methods
    }
}