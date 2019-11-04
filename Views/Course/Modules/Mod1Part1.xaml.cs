using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TEFL_App.Helpers;
using static TEFL_App.Views.Course.Modules.Mod1Part1PageTextClass;

namespace TEFL_App.Views.Course.Modules
{
    /// <summary>
    /// Interaction logic for Mod1Part1.xaml
    /// </summary>
    public partial class Mod1Part1 : Page
    {
        #region Private Fields

        private Action<Page> NavigateTo;

        #endregion Private Fields

        #region Public Constructors

        public Mod1Part1(string focusElementID, Action<Page> navigateTo)
        {
            NavigateTo = navigateTo;

            InitializeComponent();

            Loaded += (s, e) => { this.ScrollIntoViewByName(focusElementID, "ScrollArea"); };
        }

        #endregion Public Constructors

        #region Public Properties

        public Mod1Part1PageText PageText { get; set; } = App.Settings.CultureInfo == Enums.Language.English
                    ? Mod1Part1PageTextEN
                    : Mod1Part1PageTextZH;

        #endregion Public Properties

        #region Private Methods

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void LessonPlanLink_Click(object sender, RoutedEventArgs e)
        {
            if (App.StudentProfile.ID > 0)
            {
                NavigateTo(new LessonPlanPage());
            }
            else
            {
                Functions.ShowMessageDialog("", PageText.NoProfileError);
            }
        }

        private void ProfilePageLink_Click(object sender, RoutedEventArgs e)
        {
            if (App.StudentProfile.ID > 0)
            {
                Functions.ShowStudentProfile(App.StudentProfile);
            }
            else
            {
                Functions.ShowMessageDialog("", PageText.NoProfileError);
            }
        }

        #endregion Private Methods
    }

    public sealed partial class Mod1Part1PageText
    {
        #region Public Properties

        public string NoProfileError { get; set; }

        #endregion Public Properties
    }

    public sealed class Mod1Part1PageTextClass
    {
        #region Internal Fields

        internal static Mod1Part1PageText Mod1Part1PageTextEN = new Mod1Part1PageText
        {
            NoProfileError = "Pease log in using a student profile"
        };

        internal static Mod1Part1PageText Mod1Part1PageTextZH = new Mod1Part1PageText
        {
            NoProfileError = "请 log in using student profile"
        };

        #endregion Internal Fields
    }
}