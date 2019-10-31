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
            CreateChapterMenuButtons();

            if (App.UserType == Helpers.Enums.UserType.Manager)
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

        private Button ChapterSectionBtn(string chapterNum, string chapterTitle)
        {
            Grid buttonContent = new Grid { Style = TryFindResource("ChapterSectionGrid") as Style};
            
            buttonContent.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            buttonContent.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });

            var numberText = new TextBlock
            {
                Style = TryFindResource("ChapterSectionNumber") as Style,
                Text = chapterNum
            };
            var titleText = new TextBlock
            {
                Style = TryFindResource("ChapterSectionText") as Style,
                Text = chapterTitle
            };

            buttonContent.Children.Add(numberText);
            buttonContent.Children.Add(titleText);

            Grid.SetColumn(numberText, 0);
            Grid.SetColumn(titleText, 1);

            return new Button
            {
                Style = TryFindResource("SectionBtnStyle") as Style,
                Content = new Frame
                {
                    Style = TryFindResource("MenuTitleStyle") as Style,
                    Content = buttonContent
                }
            };
        }

        private Button ChapterTitleBtn(string sectionTitle)
        {
            return new Button
            {
                Style = TryFindResource("ChapterBtnStyle") as Style,
                Content = new Frame
                {
                    Style = TryFindResource("MenuSectionStyle") as Style,
                    Content = new Label
                    {
                        Content = string.Format("{0}", sectionTitle),
                        Style = TryFindResource("MenuSectionStyleText") as Style,
                    }
                }
            };
        }

        private void CreateChapterMenuButtons()
        {
            string currentModule = "0";
            string currentChapter = "0";
            string currentSection = "0";

            foreach (var x in CourseData.CourseData.Chapters)
            {
                //Module numbers take the form "x.x.x" -> "module.chapter.section"
                string[] moduleData = x.Number.Split('.');

                //Module Title
                if (currentModule != moduleData[0])
                {
                    ModuleChaptersStackPanel.Children.Add(ModuleTitleFrame(currentModule));
                }

                if (currentChapter != moduleData[1])
                //Chapter Title
                {
                    ModuleChaptersStackPanel.Children.Add(ChapterTitleBtn(x.Title));
                }
                else
                //Section Title
                {
                    string sectionTitle = string.Format("Part {0} - {1}", currentChapter, x.Title);
                    ModuleChaptersStackPanel.Children.Add(ChapterSectionBtn(x.Number, x.Title));
                }

                currentModule = moduleData[0];
                currentChapter = moduleData[1];
                currentSection = moduleData[2];
            }
        }

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

        private Frame ModuleTitleFrame(string module)
        {
            return new Frame
            {
                Style = TryFindResource("MenuHeaderStyle") as Style,
                Content = new Label
                {
                    Content = string.Format("Module {0}", module),
                    Style = TryFindResource("MenuHeaderStyleText") as Style
                }
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