using System.Collections.Generic;

namespace TEFL_App.Models
{
    public class ManagerLoginResult
    {
        #region Public Properties

        public List<TEFLProfile> TEFLProfiles { get; set; }
        public Employer User { get; set; }

        #endregion Public Properties
    }
}