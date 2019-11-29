using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            SetupExceptionHandling();
        }

        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) => LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) => LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");

            TaskScheduler.UnobservedTaskException += (s, e) => LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        private void LogUnhandledException(Exception exception, string source)
        {
            string message = $"Unhandled exception ({source})";
            //var file = System.IO.File.CreateText("newFile.txt");

            try
            {
                AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
                message = $"Unhandled exception in {assemblyName.Name} v{assemblyName.Version} ({source})";
            }
            catch (Exception ex)
            {
               // file.WriteLine(ex.Message);
                //_Logger.Fatal(ex, "Exception in LogUnhandledException");
            }
            finally
            {
               // file.WriteLine(exception.Message + "\n" + message);
                //_Logger.Fatal(exception, message);
                MessageBox.Show($"An unexpected error occurred. Please contact Support if the error persists. \n\n {exception.Message} \n\n {exception.StackTrace}", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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