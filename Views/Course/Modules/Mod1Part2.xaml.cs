using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TEFL_App.Views.Course.Modules
{
    /// <summary>
    /// Interaction logic for Mod1Part2.xaml
    /// </summary>
    public partial class Mod1Part2 : Page
    {
        #region Private Fields

        private Action<Page> NavigateTo;

        #endregion Private Fields

        #region Public Constructors

        public Mod1Part2(string focusElementID, Action<Page> navigateTo)
        {
            NavigateTo = navigateTo;

            InitializeComponent();

            Loaded += (s, e) => { this.ScrollIntoViewByName(focusElementID, "ScrollArea"); };
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        #endregion Public Constructors
    }
}
