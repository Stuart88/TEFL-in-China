using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Windows;
using TEFL_App.DataLayer;
using TEFL_App.Models;
using static TEFL_App.Helpers.Enums;

namespace TEFL_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Public Fields

        public static readonly HttpClient client = new HttpClient();
        public static readonly int VersionNumber = 1;
        public static Employer ManagerProfile = new Employer();
        public static TEFLProfile StudentProfile = new TEFLProfile();

        #endregion Public Fields

        #region Public Constructors

        public App()
        {
            DbContext.Initialise();

            RememberMeData = DbContext.GetAllRememberMeData();
            Settings = DbContext.GetAppSettings();

            CultureInfo = new CultureInfo(Settings.CultureInfo);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo;

            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public static CultureInfo CultureInfo { get; set; }
        public static List<DbRememberMe> RememberMeData { get; set; }
        public static DbAppSettings Settings { get; set; }
        public static List<TEFLProfile> TEFLProfiles { get; set; }
        public static string UserLogin { get; set; } = "";
        public static string UserPassword { get; set; } = "";
        public static UserType UserType { get; set; }

        #endregion Public Properties
    }
}