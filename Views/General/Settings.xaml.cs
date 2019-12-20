using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using TEFL_App.Helpers;
using static TEFL_App.Views.General.SettingsPageTextClass;

namespace TEFL_App.Views.General
{
    public partial class Settings : Page
    {
        #region Private Fields

        private Action AfterSaveComplete;
        private DataLayer.DbAppSettings AppSettingsToSave = App.Settings;

        #endregion Private Fields

        #region Public Constructors

        public Settings(Action afterSaveComplete)
        {
            InitializeComponent();
            SetLanguage();

            AfterSaveComplete = afterSaveComplete;

            languageComboBox.SelectedItem = App.Settings.CultureInfo switch
            {
                Enums.Language.English => langItemEn,
                Enums.Language.Chinese => langItemZh,
                _ => langItemZh,
            };

            PasswordChangeArea.Visibility = App.UserType == Helpers.Enums.UserType.Manager
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        #endregion Public Constructors

        #region Public Properties

        public SettingsPageText PageText { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            AppSettingsToSave.CultureInfo = (((ComboBox)sender).SelectedItem as ComboBoxItem).Tag switch
            {
                "English" => Enums.Language.English,
                "Chinese" => Enums.Language.Chinese,
                _ => Enums.Language.Chinese
            };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataLayer.DbContext.UpdateAppSettings(AppSettingsToSave);

            SetLanguage();

            AfterSaveComplete();

            Functions.ShowMessageDialog("", PageText.SavedSuccess);
        }

        private void SetComponentsText()
        {
            saveBtn.Content = PageText.Save;
            languageLabel.Content = PageText.Language;
            PasswordInputLabel.Content = PageText.Password;
            PasswordInputLabel1.Content = PageText.Password;
            PasswordInputLabel2.Content = PageText.RetypePassword;
            ManagerPasswordLabel.Content = PageText.ManagerPassword;
            ChangePasswordBtn.Content = PageText.Submit;
            PasswordInfoText.Text = PageText.PasswordInfo;
            SettingsTitle.Text = PageText.Settings;
        }

        private void SetLanguage()
        {
            PageText = App.Settings.CultureInfo == Helpers.Enums.Language.English
                ? SettingsPageTextEn
            : SettingsPageTextZH;

            SetComponentsText();
        }

        #endregion Private Methods

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            string newPass = PasswordInput.Text;
            string newPass2 = PasswordInput2.Text;

            if (newPass != newPass2)
            {
                Helpers.Functions.ShowMessageDialog("", PageText.PasswordsDoNotMatch);
            }
            else
            {
                var messageBoxResult = MessageBox.Show(PageText.Confirmation, "", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    SubmitNewPassword(newPass);
                }
            }
        }

        private async void SubmitNewPassword(string pass)
        {
            try
            {
                string authHeader = Functions.Base64Encode(string.Format("{0}:{1};{2}", App.ManagerProfile.ID, ManagerPassword.Password, pass));

                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

                string json_data = await App.client.GetStringAsync(Globals.baseURL + "UpdatePass");

                if (!string.IsNullOrEmpty(json_data))
                {
                    JsonBasicResult<object> json = JsonConvert.DeserializeObject<JsonBasicResult<object>>(json_data);
                    if (json.ok)
                    {
                        Functions.ShowMessageDialog("", PageText.SavedSuccess);
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
            catch (Exception e)
            {
                Functions.ShowErrorMessageDialog(e);
            }
        }
    }

    public sealed partial class SettingsPageText
    {
        #region Public Properties

        public string Confirmation { get; set; }
        public string Language { get; set; }
        public string ManagerPassword { get; set; }
        public string Password { get; set; }
        public string PasswordsDoNotMatch { get; set; }
        public string RetypePassword { get; set; }
        public string Save { get; set; }
        public string PasswordInfo { get; set; }
        public string SavedSuccess { get; set; }
        public string Submit { get; set; }
        public string Settings { get; set; }

        #endregion Public Properties
    }

    public sealed class SettingsPageTextClass
    {
        #region Internal Fields

        internal static SettingsPageText SettingsPageTextEn = new SettingsPageText
        {
            Save = "Save Language",
            PasswordInfo = "Here you can set the password your staff use to login to this software",
            Submit = "Change Password",
            Confirmation = "Are you sure?",
            PasswordsDoNotMatch = "Passwords do not match!",
            SavedSuccess = "Settings saved!",
            Language = "Language",
            Password = "New Staff Password",
            RetypePassword = "Retype password",
            ManagerPassword = "Please provide your eChinaCareers login password",
            Settings = "Settings"
        };

        internal static SettingsPageText SettingsPageTextZH = new SettingsPageText
        {
            Save = "保存设置",
            Submit = "提交新密码",
            PasswordInfo = "在此重置您的登陆密码",
            PasswordsDoNotMatch = "密码不 the same!",
            Confirmation = "确定？",
            SavedSuccess = "成功！",
            Language = "语言",
            Password = "请输入新密码",
            RetypePassword = "请再次输入",
            ManagerPassword = "请输入您的eChinaCareers用户登陆密码",
            Settings = "设置"
        };

        #endregion Internal Fields
    }
}