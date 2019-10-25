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

        public static void AddProfilePic(DbProfilePic pic)
        {
            DbProfilePic adding = new DbProfilePic
            {
                CandidateID = pic.CandidateID,
                ImageBytes = pic.ImageBytes
            };

            _ = db.Insert(adding);
        }

        public static bool PictureExists(int candID)
        {
            return GetProfilePic(candID, out _);
        }

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

        public static void AddVerified(DbVerified v)
        {
            DbVerified adding = new DbVerified
            {
                Email = v.Email
            };

            _ = db.Insert(adding);
        }

        public static void DeleteProfilePic(int candID)
        {
            if(GetProfilePic(candID, out DbProfilePic deleting))
            {
                _ = db.Delete(deleting);
            }
        }
        public static void DeleteProfilePic(DbProfilePic pic)
        {
            _ = db.Delete(pic);
        }

        public static void DeleteRememberMe(DbRememberMe data)
        {
            //DbVerified updating = db.Find<DbVerified>(profile);

            _ = db.Delete(data);
        }

        public static void DeleteSettings(DbAppSettings data)
        {
            _ = db.Delete(data);
        }

        public static void DeleteVerified(DbVerified profile)
        {
            //DbVerified updating = db.Find<DbVerified>(profile);

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

        public static List<DbVerified> GetDbVerifieds()
        {
            return db.Table<DbVerified>().ToList();
        }

        public static bool GetProfilePic(int candID, out DbProfilePic pic)
        {
            pic = db.Table<DbProfilePic>().FirstOrDefault(x => x.CandidateID == candID);

            return pic != null;
        }

        public static void Initialise()
        {
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeflApp.db");

            _ = db.CreateTable<DbVerified>();
            _ = db.CreateTable<DbRememberMe>();
            _ = db.CreateTable<DbAppSettings>();
            _ = db.CreateTable<DbProfilePic>();
        }

        public static void UpdateAppSettings(DbAppSettings data)
        {
            _ = db.Update(data);
        }

        public static void UpdateProfilePic(DbProfilePic pic)
        {
            _ = db.Update(pic);
        }

        public static void UpdateRememberMe(DbRememberMe data)
        {
            _ = db.Update(data);
        }

        public static void UpdateVerified(DbVerified profile)
        {
            _ = db.Update(profile);
        }

        #endregion Public Methods
    }
}