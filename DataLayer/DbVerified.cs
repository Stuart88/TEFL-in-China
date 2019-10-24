using SQLite;

namespace TEFL_App.DataLayer
{
    public class DbVerified
    {
        #region Public Properties

        [NotNull]
        public string Email { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }



        #endregion Public Properties
    }
}