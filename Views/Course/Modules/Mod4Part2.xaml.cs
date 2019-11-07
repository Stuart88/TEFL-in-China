using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TEFL_App.Helpers;
using static TEFL_App.Views.Course.Modules.Mod4Part2PageTextClass;

namespace TEFL_App.Views.Course.Modules
{
    /// <summary>
    /// Interaction logic for Mod4Part2.xaml
    /// </summary>
    public partial class Mod4Part2 : Page
    {
        #region Private Fields

        private Action<Page> NavigateTo;

        #endregion Private Fields

        #region Public Constructors

        public Mod4Part2(string focusElementID, Action<Page> navigateTo)
        {
            NavigateTo = navigateTo;

            InitializeComponent();

            TEFLVerifyLink.NavigateUri = new Uri(string.Format("https://www.echinacareers.com/TEFLApp/TEFLVerify?certificateID={0}", App.StudentProfile.CertificateID));

            Loaded += (s, e) => { this.ScrollIntoViewByName(focusElementID, "ScrollArea"); };
        }

        #endregion Public Constructors

        #region Public Properties

        public Mod4Part2PageText PageText { get; set; } = App.Settings.CultureInfo == Enums.Language.English
                    ? Mod4Part2PageTextEN
                    : Mod4Part2PageTextZH;

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

        private void FinalExamPage_Click(object sender, RoutedEventArgs e)
        {
            if (App.StudentProfile.ID > 0)
            {
                NavigateTo(new FinalExam());
            }
            else
            {
                Functions.ShowMessageDialog("", PageText.NoProfileError);
            }
        }

        #endregion Private Methods
    }

    public sealed partial class Mod4Part2PageText
    {
        #region Public Properties

        public string NoProfileError { get; set; }

        #endregion Public Properties
    }

    public sealed class Mod4Part2PageTextClass
    {
        #region Internal Fields

        internal static Mod4Part2PageText Mod4Part2PageTextEN = new Mod4Part2PageText
        {
            NoProfileError = "Pease log in using a student profile"
        };

        internal static Mod4Part2PageText Mod4Part2PageTextZH = new Mod4Part2PageText
        {
            NoProfileError = "请 log in using student profile"
        };

        #endregion Internal Fields
    }
}