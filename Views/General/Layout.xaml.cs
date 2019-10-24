using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TEFL_App.Views.Course;
using TEFL_App.Views.Management;
using static TEFL_App.Views.General.LayoutPageTextClass;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        #region Private Fields

        private Action OnLogout;

        #endregion Private Fields

        #region Public Constructors

        public Layout(Action onLogout)
        {
            InitializeComponent();

            SetLanguage();

            if(App.UserType == Helpers.Enums.UserType.Manager)
            {
                ContentArea.Content = new ManagerHome();
            }
            else
            {
                ContentArea.Content = new CourseHome();
            }

            OnLogout = onLogout;
        }

        #endregion Public Constructors

        #region Public Properties

        public LayoutPageText PageText { get; set; }

        public Visibility UserIsCandidate { get; set; } = App.UserType == Helpers.Enums.UserType.Candidate
            ? Visibility.Visible
            : Visibility.Collapsed;

        public Visibility UserIsManager { get; set; } = App.UserType == Helpers.Enums.UserType.Manager
            ? Visibility.Visible
            : Visibility.Collapsed;

        #endregion Public Properties

        #region Private Methods

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.ManagerProfile = new Models.Employer();
            App.TEFLProfiles = new List<Models.TEFLProfile>();

            OnLogout();
        }

        private void MenuBtnClick(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = ((Button)sender).Tag switch
            {
                "ManagerHome" => new ManagerHome(),
                "CourseHome" => new CourseHome(),
                "Staff" => new Staff(),
                "Course" => new TEFLCourse(),
                "Help" => new Help(),
                "Settings" => new Settings(SetLanguage),
                _ => new ManagerHome()
            };
        }

        private void SetButtonsText()
        {
            managerHomeBtn.Content = PageText.Home;
            courseHomeBtn.Content = PageText.Home;
            courseBtn.Content = PageText.Course;
            staffBtn.Content = PageText.Staff;
            settingsBtn.Content = PageText.Settings;
            helpBtn.Content = PageText.Help;
            logoutBtn.Content = PageText.Logout;
        }

        private void SetLanguage()
        {
            PageText = App.Settings.CultureInfo == Helpers.Enums.Language.English
            ? LayoutPageTextEn
            : LayoutPageTextZH;

            SetButtonsText();
        }

        #endregion Private Methods
    }

    public sealed partial class LayoutPageText
    {
        #region Public Properties

        public string Course { get; set; }
        public string Help { get; set; }
        public string Home { get; set; }
        public string Logout { get; set; }
        public string Settings { get; set; }
        public string Staff { get; set; }

        #endregion Public Properties
    }

    public sealed class LayoutPageTextClass
    {
        #region Internal Fields

        internal static LayoutPageText LayoutPageTextEn = new LayoutPageText
        {
            Home = "Home",
            Staff = "Staff",
            Course = "TEFL Course",
            Settings = "Settings",
            Help = "Help",
            Logout = "Log Out"
        };

        internal static LayoutPageText LayoutPageTextZH = new LayoutPageText
        {
            Home = "主页",
            Staff = "人工",
            Course = "TEFL 教程",
            Settings = "设备",
            Help = "Help",
            Logout = "退出"
        };

        #endregion Internal Fields
    }
}