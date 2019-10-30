using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for LoginManager.xaml
    /// </summary>
    public partial class LoginStudent : UserControl
    {
        #region Private Fields

        private Action<Page> SetMainWindowContent;

        #endregion Private Fields

        #region Public Constructors

        public LoginStudent(Action<Page> setMainWindowContent)
        {
            InitializeComponent();

            SetMainWindowContent = setMainWindowContent;

            DbRememberMe = DbContext.GetAllRememberMeData()
                .Where(x => x.Type == (int)DataLayer.Enums.RememberMeType.Candidate)
                .FirstOrDefault();

            if (DbRememberMe != null)
            {
                Email = DbRememberMe.Email;
                UsernameInput.Text = DbRememberMe.Email;

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
        }

        private async void ProcessLogin()
        {
            try
            {
                UsernameInput.IsEnabled = false;
                PasswordInput.IsEnabled = false;
                LoginBtn.IsEnabled = false;
                RememberMeCheckbox.IsEnabled = false;

                App.UserLogin = UsernameInput.Text;
                App.UserPassword = PasswordInput.Password;

                string userData = Functions.Base64Encode(string.Format("{0};{1}:{2}", App.ManagerProfile.ID, App.UserLogin, App.UserPassword));

                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

                string json_data = await App.client.GetStringAsync(Globals.baseURL + "StudentLogin");

                if (!string.IsNullOrEmpty(json_data))
                {
                    JsonBasicResult<TEFLProfile> json = JsonConvert.DeserializeObject<JsonBasicResult<TEFLProfile>>(json_data);
                    if (json.ok)
                    {
                        if (RememberMe)
                        {
                            DbContext.AddRememberMe(new DbRememberMe { Email = UsernameInput.Text, Type = (int)DataLayer.Enums.RememberMeType.Candidate });
                        }
                        else if (DbRememberMe != null)
                        {
                            DbContext.DeleteRememberMe(DbRememberMe);
                        }

                        App.UserType = Helpers.Enums.UserType.Candidate;
                        App.StudentProfile = json.data;
                        SetMainWindowContent(new Layout(Logout));
                    }
                    else
                        throw new Exception(json.message);
                }
                else
                    throw new Exception("Username or password incorrect!");

            }
            catch (Exception ex)
            {
                Functions.ShowErrorMessageDialog(ex);
                UsernameInput.IsEnabled = true;
                PasswordInput.IsEnabled = true;
                LoginBtn.IsEnabled = true;
                RememberMeCheckbox.IsEnabled = true;
            }
        }

     
        private void RememberMeCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            RememberMe = (bool)((CheckBox)sender).IsChecked;
        }

      

        #endregion Private Methods
    }
}