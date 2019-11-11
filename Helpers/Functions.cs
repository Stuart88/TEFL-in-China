using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
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

        public static string HighestExamScoreString(string scores)
        {
            if (string.IsNullOrEmpty(scores))
                return " - ";
            else
            {
                List<int> scoresList = scores.Split(',').Select(s => int.Parse(s)).ToList();

                if (scoresList.Count() > 0)
                    return scoresList.Max().ToString();
                else
                    return " - ";
            }
        }

        public static string HighestExamScoreString(string[] scores)
        {
            if (scores.Length > 0)
                return scores.Max().ToString();
            else
                return " - ";
        }

        public static int HighestExamScore(string scores)
        {
            if (string.IsNullOrEmpty(scores))
                return 0;
            else
            {
                List<int> scoresList = scores.Split(',')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(s => int.Parse(s))
                    .ToList();

                if (scoresList.Count() > 0)
                    return scoresList.Max();
                else
                    return 0;
            }
        }

        public static int HighestExamScore(string[] scores)
        {
            if (scores.Length > 0)
                return scores.Where(x => !string.IsNullOrEmpty(x))
                    .Select(s => int.Parse(s))
                    .Max();
            else
                return 0;
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

        public static BitmapImage LoadImage(byte[] imageData)
        {
            
            if (imageData == null || imageData.Length == 0)
            {
                throw new Exception("No image data!");
            }
            else
            {
                BitmapImage image = new BitmapImage();

                using var mem = new MemoryStream(imageData);

                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();

                image.Freeze();

                return image;
            }
        }

        public static byte[] ImageToByteArray(BitmapImage imageIn)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
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

        public static void BringIntoViewByName(this Page page, string name)
        {
            var element = page.FindName(name);
            if (element != null)
            {
                (element as RichTextBox).BringIntoView();
            }
          
        }

        public static void ScrollIntoViewByName(this Page page, string name, string scrollerName)
        {
            var element = page.FindName(name) as RichTextBox;
            var scroller = page.FindName(scrollerName) as ScrollViewer;
            
            if (element != null && scroller != null && scroller is ScrollViewer)
            {
                var pos = (element).TransformToAncestor(scroller.Content as StackPanel).Transform(new Point(0, 0));

                (scroller).ScrollToVerticalOffset(pos.Y);
            }

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

        public static void ShowStudentProfile(TEFLProfile profile)
        {
            try
            {
                Views.General.PopupWindow popUp = new Views.General.PopupWindow(profile.Name);
                popUp.Content = new Views.Student.StudentProfile(profile);
                popUp.Show();
            }
            catch(Exception e)
            {
                ShowErrorMessageDialog(e);
            }
        }
        public static string ToStringCustom(this DateTime d)
        {
            return App.Settings.CultureInfo switch
            {
                Enums.Language.English => d.ToString("dd MMM yyyy", App.CultureInfo),
                Enums.Language.Chinese => d.ToString("yyyy年MM月dd日", App.CultureInfo),
                _ => d.ToString("yyyy年MM月dd日", App.CultureInfo)
            };
        }

        #endregion Public Methods
    }
}