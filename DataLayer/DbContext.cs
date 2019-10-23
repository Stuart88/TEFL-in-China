using SQLite;
using System.Collections.Generic;

namespace TEFL_App.DataLayer
{
    public static class DbContext
    {
        #region Private Fields

        private static SQLiteConnection db = new SQLiteConnection("TeflApp.db");

        #endregion Private Fields

        #region Public Methods

        public static void AddRememberMe(DbRememberMe rememberMeData)
        {
            DbRememberMe adding = new DbRememberMe
            {
                Email = rememberMeData.Email,
                Type = rememberMeData.Type
            };

            _ = db.Insert(adding);
        }

        public static void AddSettings(DbAppSettings settings)
        {
            DbAppSettings adding = new DbAppSettings
            {
                CultureInfo = settings.CultureInfo
            };

            _ = db.Insert(adding);
        }

        public static void AddTeflProfile(DbTEFLProfile profile)
        {
            DbTEFLProfile adding = new DbTEFLProfile
            {
                AppPassword = profile.AppPassword,
                AppUsername = profile.AppUsername,
                CandidateID = profile.CandidateID
            };

            _ = db.Insert(adding);
        }

        public static void DeleteRememberMe(DbRememberMe data)
        {
            //DbTEFLProfile updating = db.Find<DbTEFLProfile>(profile);

            _ = db.Delete(data);
        }

        public static void DeleteSettings(DbAppSettings data)
        {
            _ = db.Delete(data);
        }

        public static void DeleteTeflProfile(DbTEFLProfile profile)
        {
            //DbTEFLProfile updating = db.Find<DbTEFLProfile>(profile);

            _ = db.Delete(profile);
        }

        public static List<DbRememberMe> GetAllRememberMeData()
        {
            return db.Table<DbRememberMe>().ToList();
        }

        public static DbAppSettings GetAppSettings()
        {
            DbAppSettings settings = db.Table<DbAppSettings>().FirstOrDefault();

            if (settings == null)
            {
                settings = new DbAppSettings();
                AddSettings(settings);
            }

            return settings;
        }

        public static List<DbTEFLProfile> GetDbTEFLProfiles()
        {
            return db.Table<DbTEFLProfile>().ToList();
        }

        public static void Initialise()
        {
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeflApp.db");

            _ = db.CreateTable<DbTEFLProfile>();
            _ = db.CreateTable<DbRememberMe>();
            _ = db.CreateTable<DbAppSettings>();
        }

        public static void UpdateAppSettings(DbAppSettings data)
        {
            _ = db.Update(data);
        }

        public static void UpdateRememberMe(DbRememberMe data)
        {
            _ = db.Update(data);
        }

        public static void UpdateTeflProfile(DbTEFLProfile profile)
        {
            _ = db.Update(profile);
        }

        #endregion Public Methods
    }
}