using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TEFL_App.DataLayer;
using TEFL_App.Helpers;
using TEFL_App.Models;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        #region Private Fields

        private Action<Page> SetMainWindowContent;
        private readonly SolidColorBrush ManagerBtnBorderColour = new SolidColorBrush(Colors.Blue);
        private readonly SolidColorBrush StudentBtnBorderColour = new SolidColorBrush(Colors.OrangeRed);
        #endregion Private Fields

        #region Public Constructors

        public Login(Action<Page> setMainWindowContent)
        {
            InitializeComponent();

            SetMainWindowContent = setMainWindowContent;

            Loaded += async (s, e) =>
            {
                await AutoFetchData();
            };

            loginFrame.Content = new LoginManager(SetMainWindowContent);

            managerLoginBtn.BorderBrush = ManagerBtnBorderColour;
        }

        #endregion Public Constructors

        #region Private Methods

        private async Task AutoFetchData()
        {
            try
            {

                if (Functions.AppVerified(out string email))
                {
                    string userData = Functions.Base64Encode(string.Format("{0}:{1}", email, ""));

                    App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

                    string json_data = await App.client.GetStringAsync(Globals.baseURL + "GetAppData");

                    if (!string.IsNullOrEmpty(json_data))
                    {
                        JsonBasicResult<ManagerLoginResult> json = JsonConvert.DeserializeObject<JsonBasicResult<ManagerLoginResult>>(json_data);
                        if (json.ok)
                        {

                            Application.Current.Dispatcher.Invoke(() => {
                                Functions.SynchroniseAppData(json.data);
                                LoginOptionBtnsStackPanel.Visibility = Visibility.Visible; 
                            });
                            
                        }
                        else
                        {
                            throw new Exception(json.message);
                        }
                    }
                    else
                    {
                        throw new Exception("No result data!");
                    }
                }
                else
                {
                    //app not been used yet, so only allow manager login
                    LoginOptionBtnsStackPanel.Visibility = Visibility.Visible;
                    //LoginOptionBtnsStackPanel.Visibility = Visibility.Hidden;
                }
            }
            catch(Exception e)
            {
                Functions.ShowErrorMessageDialog(e);
            }

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string tag = (string)((Button)sender).Tag;

            //reset border colours
            managerLoginBtn.BorderBrush = FindResource("LightGrey") as SolidColorBrush;
            studentLoginBtn.BorderBrush = FindResource("LightGrey") as SolidColorBrush;

            //set bolder border colour for chosen button
            ((Button)sender).BorderBrush = tag switch
            {
                "Manager" => ManagerBtnBorderColour,
                "Student" => StudentBtnBorderColour,
                _ => throw new Exception("How did we get here!")
            };

            //choose correct login input section
            loginFrame.Content = tag switch
            {
                "Manager" => new LoginManager(SetMainWindowContent),
                "Student" => new LoginStudent(SetMainWindowContent),
                _ => throw new Exception("How did we get here!")
            };
        }

        #endregion Private Methods
    }
}