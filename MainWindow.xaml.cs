using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http.Headers;
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
using TEFL_App.Models;

namespace TEFL_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool RememberMe { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ProcessLogin()
        {
            try
            {
                EmailInput.IsEnabled = false;
                PasswordInput.IsEnabled = false;
                LoginBtn.IsEnabled = false;
                //rememberMeCheckbox.IsEnabled = false;

                App.UserEmail = EmailInput.Text;
                App.UserPassword = PasswordInput.Password;

                string userData = Functions.Base64Encode(string.Format("{0}:{1}", App.UserEmail, App.UserPassword));

                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

                string json_data = await App.client.GetStringAsync(Globals.baseURL + "Login");

                if (!string.IsNullOrEmpty(json_data))
                {
                    JsonBasicResult<ManagerLoginResult> json = JsonConvert.DeserializeObject<JsonBasicResult<ManagerLoginResult>>(json_data);
                    if (json.ok)
                    {
                        App.ManagerProfile = json.data.User;
                        App.TEFLProfiles = json.data.TEFLProfiles;

                        //await Task.Run(async () =>
                        //{
                        //    await GetIndustriesList();
                        //    await GetCompanyNamesList();
                        //    await GetJobFunctionsList();
                        //    await GetAdminsList();
                        //});


                        this.Content = new Views.Management.ManagerHome();

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
            catch (Exception ex)
            {
                Functions.ShowErrorMessageDialog(ex);
                EmailInput.IsEnabled = true;
                PasswordInput.IsEnabled = true;
                LoginBtn.IsEnabled = true;
                //rememberMeCheckbox.IsEnabled = true;
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessLogin();
        }
    }
}
