using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TEFL_App.Views.Course;
using TEFL_App.Views.Management;
using System.Linq;
using static TEFL_App.Views.General.LayoutPageTextClass;
using static TEFL_App.Helpers.QuizQuestions;
using System.Windows.Media.Animation;
using TEFL_App.Helpers;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        #region Private Fields

        private Action OnLogout;
        private Page ViewingPage = new Page();

        #endregion Private Fields

        #region Public Constructors

      

        public Layout(Action onLogout)
        {
            InitializeComponent();
            SetLanguage();
            CreateChapterMenuButtons();

            //Loaded += MinimiseMenu;

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

        private void MinimiseMenu(object sender, RoutedEventArgs e)
        {
            foreach(var obj in ModuleChaptersStackPanel.Children)
            {
                if(obj is StackPanel && (obj as StackPanel).Name.StartsWith("ChapterStack"))
                {
                    CreateMenuAnimation(obj as StackPanel);
                }
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public LayoutPageText PageText { get; set; }
        public Visibility UserIsCandidate { get; set; } = App.UserType == Helpers.Enums.UserType.Candidate ? Visibility.Visible : Visibility.Collapsed;
        public Visibility UserIsManager { get; set; } = App.UserType == Helpers.Enums.UserType.Manager ? Visibility.Visible : Visibility.Collapsed;

        #endregion Public Properties

        #region Private Methods

        private Button ChapterSectionBtn(CourseData.ChapterTitleData data)
        {
            

            Grid buttonContent = new Grid { Style = TryFindResource("ChapterSectionGrid") as Style };

            buttonContent.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            buttonContent.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });


            var numberText = new TextBlock
            {
                Style = TryFindResource("ChapterSectionNumber") as Style,
                Text = data.Number
            };
            var titleText = new TextBlock
            {
                Style = TryFindResource("ChapterSectionText") as Style,
                Text = data.Title
            };

            buttonContent.Children.Add(numberText);
            buttonContent.Children.Add(titleText);

            Grid.SetColumn(numberText, 0);
            Grid.SetColumn(titleText, 1);

            

            Button sectionButton = new Button
            {
                Style = TryFindResource("SectionBtnStyle") as Style,
                Content = new Frame
                {
                    Style = TryFindResource("MenuTitleStyle") as Style,
                    Content = buttonContent
                },
                //page components are named in the form "Section1_1_1"
                Tag = data// string.Format("Section{0}", data.Number.Replace('.', '_'))
            };

            sectionButton.Click += SectionButton_Click;

            return sectionButton;
        }

        private void SectionButton_Click(object sender, RoutedEventArgs e)
        {
            CourseData.ChapterTitleData data = (sender as Button).Tag as CourseData.ChapterTitleData;

            string[] pageData = data.Number.Split('.');                                                 //data.Number is of the form "1.1.3a" ---> "module.chapter.section"

            string pageGridToFind = string.Format("Mod{0}Chapter{1}Grid", pageData[0], pageData[1]);    //Mod{0}Chapter{1}Grid is based on x:Name value given to each module page.  

            var findPage = ViewingPage.FindName(pageGridToFind);


            if(findPage == null)                                                                        //Navigate to correct chapter page
            {
                string chapterIdentifier = string.Join(".", pageData.Take(2));
                ViewingPage = chapterIdentifier switch
                {
                    "1.1" => new Course.Modules.Mod1Part1(data.SectionID, NavigateTo),
                    "1.2" => new Course.Modules.Mod1Part2(data.SectionID, NavigateTo),
                    "1.3" => new Course.Modules.Mod1Part3(data.SectionID, NavigateTo),
                    "2.1" => new Course.Modules.Mod2Part1(data.SectionID, NavigateTo),
                    "2.2" => new Course.Modules.Mod2Part2(data.SectionID, NavigateTo),
                    "3.1" => new Course.Modules.Mod3Part1(data.SectionID, NavigateTo),
                    "3.2" => new Course.Modules.Mod3Part2(data.SectionID, NavigateTo),
                    "3.3" => new Course.Modules.Mod3Part3(data.SectionID, NavigateTo),
                    "3.5" => new Course.Modules.Mod3Part4(data.SectionID, NavigateTo),
                    "4.1" => new Course.Modules.Mod4Part1(data.SectionID, NavigateTo),
                    "4.2" => new Course.Modules.Mod4Part2(data.SectionID, NavigateTo),
                    _ => new ManagerHome()
                };
                ContentArea.Content = ViewingPage;
            }
            else
            {
                //Already on page. Bring chosen section into view
                ViewingPage.ScrollIntoViewByName(data.SectionID, "ScrollArea");
            }
        }



        private Button ChapterTitleBtn(CourseData.ChapterTitleData data)
        {
           

            Button chapterBtn = new Button
            {
                Style = TryFindResource("ChapterBtnStyle") as Style,
                Content = new Frame
                {
                    Style = TryFindResource("MenuSectionStyle") as Style,
                    Content = new Label
                    {
                        Content = string.Format("{0}", data.Title),
                        Style = TryFindResource("MenuSectionStyleText") as Style,
                    }
                },
                Tag = ChapterStackName(data),
            };

            chapterBtn.Click += AnimateChapterButtonsStack;

            return chapterBtn;
        }

        private void AnimateChapterButtonsStack(object sender, RoutedEventArgs e)
        {
            string panelName = (string)((Button)sender).Tag;

            if (panelName.Contains("Quiz"))
            {
                string quizIdentifier = string.Join(".", panelName.Split('_').Skip(1).Take(2).ToArray());           //panelName takes the form Quiz_1_4_0 (i.e. ChapterTitleData with Number = "1.4.0" )

               ViewingPage.Content = quizIdentifier switch
               {
                   "1.4" => new QuizPage(GetQuestions(ModuleNumber.Mod1), ModuleNumber.Mod1),
                   "2.3" => new QuizPage(GetQuestions(ModuleNumber.Mod2), ModuleNumber.Mod2),
                   "3.5" => new QuizPage(GetQuestions(ModuleNumber.Mod3), ModuleNumber.Mod3),
                   "4.3" => new QuizPage(GetQuestions(ModuleNumber.Mod4), ModuleNumber.Mod4),
                   _ => throw new Exception("Nothing found!")
               };
                try
                {
                    ContentArea.Content = ViewingPage.Content;
                }
                catch (Exception ex)
                {
                    Functions.ShowErrorMessageDialog(ex);
                }
            }
            else
            {
                StackPanel animatingPanel = (StackPanel)FindName(panelName);

                if (animatingPanel != null)
                {
                    CreateMenuAnimation(animatingPanel);

                }
            }
            

        }

        private void CreateMenuAnimation(StackPanel animatingPanel)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation();

            heightAnimation.Duration = TimeSpan.FromSeconds(0.5);
            heightAnimation.EasingFunction = new CubicEase();

            if (animatingPanel.Height == 0)
            {
                heightAnimation.From = 0d;
                heightAnimation.To = GetStackPanelHeight(animatingPanel);
            }
            else
            {
                heightAnimation.From = GetStackPanelHeight(animatingPanel);
                heightAnimation.To = 0d;
            }

            animatingPanel.BeginAnimation(StackPanel.HeightProperty, heightAnimation);
        }

        private double? GetStackPanelHeight(StackPanel animatingPanel)
        {
            double height = 0d;
            foreach(var child in animatingPanel.Children)
            {
                height += (child as FrameworkElement).ActualHeight;
            }

            return height;
        }

        private void CreateChapterMenuButtons()
        {
            string currentModule = "0";
            string currentChapter = "0";
            string currentSection = "0";


            StackPanel tempPanel = new StackPanel { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Stretch };

            foreach (var data in CourseData.CourseData.Chapters)
            {

                string[] moduleData = data.Number.Split('.');
                //Module numbers take the form "x.x.x" -> "module.chapter.section"

                //Module Title
                if (currentModule != moduleData[0])
                {
                    ModuleChaptersStackPanel.Children.Add(ModuleTitleFrame(moduleData[0]));
                }

                if (currentChapter != moduleData[1])
                //Chapter Title
                {                    
                    //onto new chapter, so add stackpanel containing all buttons from previous chapter
                    //Buttons are contained in stackpanel for animation. Stackpanel can be toggled open and closed for each chapter
                    if (tempPanel.Children.Count > 0)
                    {
                        this.RegisterName(tempPanel.Name, tempPanel);
                        //Storyboard.SetTargetName(HeightToggleAnimation, tempPanel.Name);
                        //Storyboard.SetTargetProperty(HeightToggleAnimation, new PropertyPath(StackPanel.HeightProperty));

                        ModuleChaptersStackPanel.Children.Add(tempPanel);
                        CreateMenuAnimation(tempPanel);//minimse
                        
                        
                        //clear/reset to new stackpanel
                        tempPanel = new StackPanel { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Stretch };
                    }

                    ModuleChaptersStackPanel.Children.Add(ChapterTitleBtn(data));  
                }
                else
                //Section Title
                {
                    tempPanel.Children.Add(ChapterSectionBtn(data));
                }

                //not very efficient, but this needs to be set here. Otherwise chapter number is off by one in "//Chapter Title" logic above.
                tempPanel.Name = ChapterStackName(data);

                currentModule = moduleData[0];
                currentChapter = moduleData[1];
                currentSection = moduleData[2];
            }
        }

        private string ChapterStackName(CourseData.ChapterTitleData data)
        {
            if (data.Title.Contains("Quiz"))
            {
                return string.Format("Quiz_{0}", ChapterNameString(data));
            }
            else
            {
                return string.Format("ChapterStack{0}", ChapterNameString(data));
            }
        }

        /// <summary>
        /// Returns module and chapter number of string, i.e. takes "4.1.6a" and returns "4_1"
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ChapterNameString(CourseData.ChapterTitleData data)
        {
            //Takes module and chapter number, .e.g 4.1.6a ---> {4, 1}
            var currentChapter = data.Number.Split('.').ToList().Take(2);  

            return string.Join("_", currentChapter);

        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.ManagerProfile = new Models.Employer();
            App.TEFLProfiles = new List<Models.TEFLProfile>();

            OnLogout();
        }

        private void MenuBtnClick(object sender, RoutedEventArgs e)
        {
            Page selectedPage = ((Button)sender).Tag switch
            {
                "ManagerHome" => new ManagerHome(),
                "CourseHome" => new CourseHome(),
                "Final Exam" => new QuizPage(GetQuestions(ModuleNumber.FinalExam), ModuleNumber.FinalExam),
                "Staff" => new Staff(),
                "Course" => new TEFLCourse(),
                "Assignment" => new LessonPlanPage(),
                "Help" => new Help(),
                "Settings" => new Settings(SetLanguage),
                _ => new ManagerHome()
            };


            NavigateTo(selectedPage);
        }

        private void NavigateTo(Page page)
        {
            ViewingPage = page;
            ContentArea.Content = page;
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
            finalExamBtn.Content = PageText.FinalExam;
            courseBtn.Content = PageText.Course;
            staffBtn.Content = PageText.Staff;
            settingsBtn.Content = PageText.Settings;
            assignmentBtn.Content = PageText.LessonPlan;
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
        public string LessonPlan { get; set; }
        public string FinalExam { get; set; }
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
            FinalExam = "Final Exam",
            Staff = "Staff",
            Course = "TEFL Course",
            LessonPlan = "Lesson Plan",
            Settings = "Settings",
            Help = "Help",
            Logout = "Log Out"
        };

        internal static LayoutPageText LayoutPageTextZH = new LayoutPageText
        {
            Home = "主页",
            Staff = "人工",
            FinalExam = "考试",
            Course = "TEFL 教程",
            LessonPlan = "Lesson Plan",
            Settings = "设备",
            Help = "Help",
            Logout = "退出"
        };

        #endregion Internal Fields
    }
}