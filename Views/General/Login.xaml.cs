using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private Action<Page> SetMainWindowContent;
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool RememberMe { get; set; } = false;
        public Login(Action<Page> setMainWindowContent)
        {
            InitializeComponent();

            SetMainWindowContent = setMainWindowContent;

            DbRememberMe = DbContext.GetAllRememberMeData().FirstOrDefault();

            if (DbRememberMe != null)
            {
                Email = DbRememberMe.Email;
                EmailInput.Text = DbRememberMe.Email;

                RememberMe = true;
                RememberMeCheckbox.IsChecked = true;
            }
        }

        #region Private Properties

        private DbRememberMe DbRememberMe { get; set; }

        #endregion Private Properties

        #region Private Methods

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessLogin();
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
                        SynchroniseAppData(json.data);

                        if (RememberMe)
                        {
                            DbContext.AddRememberMe(new DbRememberMe { Email = EmailInput.Text, Type = (int)DataLayer.Enums.RememberMeType.Manager });
                        }
                        else if (DbRememberMe != null)
                        {
                            DbContext.DeleteRememberMe(DbRememberMe);
                        }

                        //await Task.Run(async () =>
                        //{
                        //    await GetIndustriesList();
                        //    await GetCompanyNamesList();
                        //    await GetJobFunctionsList();
                        //    await GetAdminsList();
                        //});


                        SetMainWindowContent(new Management.Layout(Logout));
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

        private void Logout()
        {
            SetMainWindowContent(new Login(SetMainWindowContent));
        }
        private void RememberMeCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            RememberMe = (bool)((CheckBox)sender).IsChecked;
        }

        /// <summary>
        /// Ensures remote server and local data are sychronised. Changes on remove server will result in creation or deletion of local data.
        /// </summary>
        /// <param name="data"></param>
        private void SynchroniseAppData(ManagerLoginResult data)
        {
            App.ManagerProfile = data.User;
            App.TEFLProfiles = data.TEFLProfiles;

            List<DbTEFLProfile> localData = DbContext.GetDbTEFLProfiles();

            foreach (var localProfile in localData)
            {
                //Delete entries which do not exist any more on the remote server
                if (App.TEFLProfiles.Any(x => x.ID == localProfile.ID))
                {
                    DbContext.DeleteTeflProfile(localProfile);
                }
            }

            foreach (var profile in App.TEFLProfiles)
            {
                //Add new entries found on remove server
                if (!localData.Any(x => x.CandidateID == profile.ID))
                {
                    DbContext.AddTeflProfile(new DbTEFLProfile { CandidateID = profile.ID });
                }
            }
        }

        #endregion Private Methods

        private void PasswordInput_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ProcessLogin();
            }
            //else
            //{
            //    e.Handled = false;
            //}
        }
    }
}
