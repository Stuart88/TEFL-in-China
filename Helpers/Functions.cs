using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using TEFL_App.DataLayer;
using TEFL_App.Models;

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

        public static byte[] GeneratePasswordHash(string password)
        {
            using Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, new byte[] { 0, 4, 5, 3, 4, 5, 6, 4, 5 })
            {
                IterationCount = 10101
            };
            return hashGenerator.GetBytes(24);
        }

        public static bool PasswordsCompare(string givenPassword, TEFLProfile profile)
        {
            if (profile.AppPassword == null || profile.AppPassword.Length == 0)
            {
                return true;

            }
            else
            {
                byte[] passwordHash = GeneratePasswordHash(givenPassword);
                return passwordHash.SequenceEqual(profile.AppPassword);
            }

           
        }

        public static bool AppVerified(out string email)
        {
            email = "";

            DbVerified verified = DbContext.GetDbVerifieds().FirstOrDefault();

            if(verified != null)
            {
                email = verified.Email;
            }
            
            return verified != null;
        }

        public static void SynchroniseAppData(ManagerLoginResult data)
        {
            App.ManagerProfile = data.User;

            App.TEFLProfiles = data.TEFLProfiles;

            foreach (var p in App.TEFLProfiles)
            {
                p.ProcessFromServer();
            }
        }

        #endregion Public Methods
    }
}