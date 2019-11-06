using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using TEFL_App.Helpers;

namespace TEFL_App.Views.Course.Modules
{
    /// <summary>
    /// Interaction logic for Mod2Part2.xaml
    /// </summary>
    public partial class Mod3Part3 : Page
    {
        #region Private Fields

        private Action<Page> NavigateTo;

        #endregion Private Fields

        #region Public Constructors

        public Mod3Part3(string focusElementID, Action<Page> navigateTo)
        {
            NavigateTo = navigateTo;

            InitializeComponent();

            Loaded += (s, e) => { this.ScrollIntoViewByName(focusElementID, "ScrollArea"); };
        }

        #endregion Public Constructors

      
    }
}