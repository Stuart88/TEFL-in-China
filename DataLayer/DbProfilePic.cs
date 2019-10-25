using SQLite;

namespace TEFL_App.DataLayer
{
    public class DbProfilePic
    {
        #region Public Properties


        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public byte[] ImageBytes { get; set; }
        [NotNull]
        public int CandidateID { get; set; }



        #endregion Public Properties
    }
}