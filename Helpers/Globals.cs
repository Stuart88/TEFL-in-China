using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.Helpers
{
    public static class Globals
    {
        #region Public Fields

        public const string baseURL = "https://echinacareers.com/TEFLApp/";

        #endregion Public Fields

        #region Public Methods

        public static string generalURL(string action, string searchTerms) => string.Format("{0}{1}?{2}", baseURL, action, searchTerms);

        public static string listURL(string listType, int page, int amount, string searchTerms) => string.Format("{0}{1}?page={2}&amount={3}&{4}", baseURL, listType, page, amount, searchTerms);

        #endregion Public Methods
    }
}
