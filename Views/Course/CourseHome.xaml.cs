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

namespace TEFL_App.Views.Course
{
    /// <summary>
    /// Interaction logic for CourseHome.xaml
    /// </summary>
    public partial class CourseHome : Page
    {
        public CourseHome()
        {
            InitializeComponent();

            ContentFrame.Content = new TEFL_App.Views.General.WelcomePage();
        }
    }
}
