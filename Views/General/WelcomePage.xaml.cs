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
using TEFL_App.Helpers;
using static TEFL_App.Views.General.WelcomePageTextClass;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePageText PageText { get; set; } = App.Settings.CultureInfo == Helpers.Enums.Language.English
                ? WelcomePageTextEN
            : WelcomePageTextZH;

        public WelcomePage()
        {
            InitializeComponent();

            if(App.UserType == Helpers.Enums.UserType.Manager)
            {
                StudentGuideArea.Visibility = Visibility.Collapsed;
                StudentIntroText.Visibility = Visibility.Collapsed;
            }
            else
            {
                ManagerGuideArea.Visibility = Visibility.Collapsed;
                ManagerIntroText.Visibility = Visibility.Collapsed;

                if (App.StudentProfile.RegistrationDate < DateTime.Now.AddMonths(-Globals.CourseExpiryTime))
                {
                    CourseExpiredText.Visibility = Visibility.Visible;
                    MainWelcomeGrid.IsEnabled = false;
                }
            }

            
        }
    }


    public sealed partial class WelcomePageText
    {
        #region Public Properties

        public string WelcomeTitle { get; set; }
        public string WelcomeText { get; set; }
        public string PleaseSetPassword { get; set; }
        public string PleaseSetPassword_Explanation { get; set; }


        #endregion Public Properties
    }

    public sealed class WelcomePageTextClass
    {
        #region Internal Fields

        internal static WelcomePageText WelcomePageTextEN = new WelcomePageText
        {
            WelcomeTitle = "Welcome!",
            WelcomeText = "Stuff stuff stuff introductor text lalala",
            PleaseSetPassword = "Please set a login password for your staff",
            PleaseSetPassword_Explanation = "Your staff will use this password to login to the software and access the course.",

        };

        internal static WelcomePageText WelcomePageTextZH = new WelcomePageText
        {
            WelcomeTitle = "欢迎！",
            WelcomeText = "Stuff stuff stuff introductor text lalala",
            PleaseSetPassword = "请选择你的员工的登录密码",
            PleaseSetPassword_Explanation = "跟这个密码您公司的员工可以登录",

        };

        #endregion Internal Fields
    }
}
