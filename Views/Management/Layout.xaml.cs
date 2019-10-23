using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static TEFL_App.Views.Management.LayoutPageTextClass;

namespace TEFL_App.Views.Management
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

            ContentArea.Content = new ManagerHome();

            OnLogout = onLogout;
        }

        #endregion Public Constructors

        #region Public Properties

        public LayoutPageText PageText { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.ManagerProfile = new Models.Employer();
            App.TEFLProfiles = new List<Models.TEFLProfile>();

            OnLogout();
        }

        private void MenuBtnClick(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = ((Button)sender).Tag switch
            {
                "Home" => new ManagerHome(),
                "Staff" => new Staff(),
                "Help" => new Help(),
                "Settings" => new General.Settings(SetLanguage),
                _ => new ManagerHome()
            };
        }

        private void SetButtonsText()
        {
            homeBtn.Content = PageText.Home;
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

    public sealed class LayoutPageTextClass
    {
        #region Internal Fields

        internal static LayoutPageText LayoutPageTextEn = new LayoutPageText
        {
            Home = "Home",
            Staff = "Staff",
            Settings = "Settings",
            Help = "Help",
            Logout = "Log Out"
        };

        internal static LayoutPageText LayoutPageTextZH = new LayoutPageText
        {
            Home = "主页",
            Staff = "人工",
            Settings = "设备",
            Help = "Help",
            Logout = "退出"
        };

        #endregion Internal Fields

        #region Public Classes

        public class LayoutPageText
        {
            #region Public Properties

            public string Help { get; set; }
            public string Home { get; set; }
            public string Logout { get; set; }
            public string Settings { get; set; }
            public string Staff { get; set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}