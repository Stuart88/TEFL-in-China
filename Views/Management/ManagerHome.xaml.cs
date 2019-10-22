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

namespace TEFL_App.Views.Management
{
    /// <summary>
    /// Interaction logic for ManagerHome.xaml
    /// </summary>
    public partial class ManagerHome : Page
    {
        public ManagerHome()
        {
            InitializeComponent();

            welcomeText.Text = string.Format("{0}, 你好！", App.ManagerProfile.DisplayNameEn);

            foreach(var v in App.TEFLProfiles)
            {
                var menuItem = new Button { Content = v.Name };
                profilesList.Children.Add(menuItem);
            }
        }
    }
}
