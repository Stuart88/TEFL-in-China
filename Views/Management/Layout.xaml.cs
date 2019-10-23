using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static TEFL_App.Views.Management.LayoutPageTextClass;

namespace TEFL_App.Views.Management
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        public LayoutPageText PageText { get; set; }
        private Action OnLogout;

        public Layout(Action onLogout)
        {

            InitializeComponent();
            
            SetLanguage();

            ContentArea.Content = new ManagerHome();

            OnLogout = onLogout;
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

        private void SetLanguage()
        {
            PageText = App.Settings.CultureInfo == Helpers.Enums.Language.English
            ? LayoutPageTextEn
            : LayoutPageTextZH;

            SetButtonsText();
        }

        private void SetButtonsText()
        {
            homeBtn.Content = PageText.Home;
            staffBtn.Content = PageText.Staff;
            settingsBtn.Content = PageText.Settings;
            helpBtn.Content = PageText.Help;
            logoutBtn.Content = PageText.Logout;
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.ManagerProfile = new Models.Employer();
            App.TEFLProfiles = new List<Models.TEFLProfile>();

            OnLogout();
        }
    }
    public sealed class LayoutPageTextClass
    {
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

        public class LayoutPageText
        {
            public string Home { get; set; }
            public string Staff { get; set; }
            public string Settings { get; set; }
            public string Help { get; set; }
            public string Logout { get; set; }

        }
    }
}
