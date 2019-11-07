using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using TEFL_App.Helpers;

namespace TEFL_App.Views.Course.Modules
{
    /// <summary>
    /// Interaction logic for Mod4Part1.xaml
    /// </summary>
    public partial class Mod4Part1 : Page
    {
        #region Private Fields

        private Action<Page> NavigateTo;

        #endregion Private Fields

        #region Public Constructors

        public Mod4Part1(string focusElementID, Action<Page> navigateTo)
        {
            NavigateTo = navigateTo;

            InitializeComponent();

            Loaded += (s, e) => { this.ScrollIntoViewByName(focusElementID, "ScrollArea"); };
        }

        #endregion Public Constructors

      
    }
}