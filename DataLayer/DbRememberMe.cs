using SQLite;

namespace TEFL_App.DataLayer
{
    public class DbRememberMe
    {
        #region Public Properties

        [NotNull]
        public string Email { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public int Type { get; set; }

        #endregion Public Properties
    }
}