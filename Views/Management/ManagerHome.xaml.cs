using System.Windows.Controls;

namespace TEFL_App.Views.Management
{
    /// <summary>
    /// Interaction logic for ManagerHome.xaml
    /// </summary>
    public partial class ManagerHome : Page
    {
        #region Public Constructors

        public ManagerHome()
        {
            InitializeComponent();

            Content = new TEFL_App.Views.General.WelcomePage();
        }

        #endregion Public Constructors
    }
}