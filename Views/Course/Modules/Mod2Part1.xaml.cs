using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using TEFL_App.Helpers;

namespace TEFL_App.Views.Course.Modules
{
    /// <summary>
    /// Interaction logic for Mod1Part1.xaml
    /// </summary>
    public partial class Mod2Part1 : Page
    {
        #region Private Fields

        private Action<Page> NavigateTo;

        #endregion Private Fields

        #region Public Constructors

        public Mod2Part1(string focusElementID, Action<Page> navigateTo)
        {
            NavigateTo = navigateTo;

            InitializeComponent();

            Loaded += (s, e) => { this.ScrollIntoViewByName(focusElementID, "ScrollArea"); };
        }

        #endregion Public Constructors

        #region Private Methods

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        #endregion Private Methods
    }
}