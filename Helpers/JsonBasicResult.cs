using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEFL_App.Helpers
{
    internal class JsonBasicResult<T>
    {
        #region Public Properties

        public T data { get; set; }
        public string message { get; set; }
        public bool ok { get; set; }

        #endregion Public Properties
    }
}
