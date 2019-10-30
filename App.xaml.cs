using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        public static UserType UserType { get; set; }
        public static string UserLogin { get; set; } = "";
        public static string UserPassword { get; set; } = "";

        public static readonly HttpClient client = new HttpClient();

        public static Employer ManagerProfile = new Employer();

        public static TEFLProfile StudentProfile = new TEFLProfile();
        public static List<TEFLProfile> TEFLProfiles { get; set; }
        public static List<DbRememberMe> RememberMeData { get; set; }
        public static DbAppSettings Settings { get; set; }
        public static CultureInfo CultureInfo { get; set; }

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

       
    }
}
