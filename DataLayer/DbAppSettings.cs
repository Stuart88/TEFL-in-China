using SQLite;

namespace TEFL_App.DataLayer
{
    public class DbAppSettings
    {
        #region Public Properties

        [NotNull]
        public string CultureInfo { get; set; } = "zh-CH";

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        #endregion Public Properties
    }
}