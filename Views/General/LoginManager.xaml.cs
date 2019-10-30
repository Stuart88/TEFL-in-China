using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using TEFL_App.DataLayer;
using TEFL_App.Helpers;
using TEFL_App.Models;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for LoginManager.xaml
    /// </summary>
    public partial class LoginManager : UserControl
    {
        #region Private Fields

        private Action<Page> SetMainWindowContent;

        #endregion Private Fields

        #region Public Constructors

        public LoginManager(Action<Page> setMainWindowContent)
        {
            InitializeComponent();

            SetMainWindowContent = setMainWindowContent;

            DbRememberMe = DbContext.GetAllRememberMeData()
                .Where(x => x.Type == (int)DataLayer.Enums.RememberMeType.Manager)
                .FirstOrDefault();

            if (DbRememberMe != null)
            {
                Email = DbRememberMe.Email;
                EmailInput.Text = DbRememberMe.Email;

                RememberMe = true;
                RememberMeCheckbox.IsChecked = true;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool RememberMe { get; set; } = false;

        #endregion Public Properties

        #region Private Properties

        private DbRememberMe DbRememberMe { get; set; }

        #endregion Private Properties

        #region Private Methods

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessLogin();
        }

        private void Logout()
        {
            SetMainWindowContent(new Login(SetMainWindowContent));
        }

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

        private async void ProcessLogin()
        {
            try
            {
                EmailInput.IsEnabled = false;
                PasswordInput.IsEnabled = false;
                LoginBtn.IsEnabled = false;
                RememberMeCheckbox.IsEnabled = false;

                App.UserLogin = EmailInput.Text;
                App.UserPassword = PasswordInput.Password;

                string userData = Functions.Base64Encode(string.Format("{0}:{1}", App.UserLogin, App.UserPassword));

                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

                string json_data = await App.client.GetStringAsync(Globals.baseURL + "ManagerLogin");

                if (!string.IsNullOrEmpty(json_data))
                {
                    JsonBasicResult<ManagerLoginResult> json = JsonConvert.DeserializeObject<JsonBasicResult<ManagerLoginResult>>(json_data);
                    if (json.ok)
                    {
                        Functions.SynchroniseAppData(json.data);

                        if (RememberMe)
                        {
                            DbContext.AddRememberMe(new DbRememberMe { Email = EmailInput.Text, Type = (int)DataLayer.Enums.RememberMeType.Manager });
                        }
                        else if (DbRememberMe != null)
                        {
                            DbContext.DeleteRememberMe(DbRememberMe);
                        }

                        if(!Functions.AppVerified(out _))
                        {
                            DbContext.AddVerified(new DbVerified { Email = EmailInput.Text });
                        }

                        App.UserType = Helpers.Enums.UserType.Manager;
                        SetMainWindowContent(new Layout(Logout));
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
                RememberMeCheckbox.IsEnabled = true;
            }
        }

        private void RememberMeCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            RememberMe = (bool)((CheckBox)sender).IsChecked;
        }

        /// <summary>
        /// Ensures remote server and local data are synchronised. Changes on remove server will result in creation or deletion of local data.
        /// </summary>
        /// <param name="data"></param>
       

       

 

        #endregion Private Methods
    }
}