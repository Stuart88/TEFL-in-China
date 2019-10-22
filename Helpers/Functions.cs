using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TEFL_App.Helpers
{
    public static class Functions
    {
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

        public static void ShowErrorMessageDialog(Exception e)
        {
            MessageBoxResult result = MessageBox.Show(ErrorMessage(e), "Error", MessageBoxButton.OK);
        }
    }
}
