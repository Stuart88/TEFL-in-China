using SQLite;

namespace TEFL_App.DataLayer
{
    public class DbTEFLProfile
    {
        #region Public Properties

        public string AppPassword { get; set; } = "";

        public string AppUsername { get; set; } = "";

        [NotNull]
        public int CandidateID { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        #endregion Public Properties
    }
}