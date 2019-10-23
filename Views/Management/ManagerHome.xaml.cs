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

            welcomeText.Text = string.Format("{0}, 你好！", App.ManagerProfile.DisplayNameEn);
        }

        #endregion Public Constructors
    }
}