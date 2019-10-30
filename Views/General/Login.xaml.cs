using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        #endregion Private Fields

        #region Public Constructors

        public Login(Action<Page> setMainWindowContent)
        {
            InitializeComponent();

            SetMainWindowContent = setMainWindowContent;

            
            _ = Task.Run(async () => 
            { 
                await AutoFetchData(); 
            });

            loginFrame.Content = new LoginManager(SetMainWindowContent);
        }

        #endregion Public Constructors

        #region Private Methods

        private async Task AutoFetchData()
        {
            

            if(Functions.AppVerified(out string email))
            {
                string userData = Functions.Base64Encode(string.Format("{0}:{1}", email, ""));

                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

                string json_data = await App.client.GetStringAsync(Globals.baseURL + "GetAppData");

                if (!string.IsNullOrEmpty(json_data))
                {
                    JsonBasicResult<ManagerLoginResult> json = JsonConvert.DeserializeObject<JsonBasicResult<ManagerLoginResult>>(json_data);
                    if (json.ok)
                    {
                        Functions.SynchroniseAppData(json.data);
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
                LoginOptionBtnsStackPanel.Visibility = Visibility.Hidden;   
            }

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string tag = (string)((Button)sender).Tag;

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