using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TEFL_App.DataLayer;
using TEFL_App.Helpers;
using static TEFL_App.Views.General.HelpPageTextClass;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Page
    {
        #region Public Constructors
        public HelpPageText PageText { get; set; } = App.Settings.CultureInfo == Helpers.Enums.Language.English
                ? HelpPageTextEn
            : HelpPageTextZH;

        public Help()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

       

        #endregion Public Constructors

        private async void SubmitBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ContactFormBox.Text.Length > 0)
            {
                Application.Current.Dispatcher.Invoke(() => {
                    ContactFormResult.Text = "";
                    ContactFormBox.IsEnabled = false;
                    SubmitBtn.IsEnabled = false;
                });

                string email = DbContext.GetDbVerifieds().FirstOrDefault().Email;

                string userData = Functions.Base64Encode(string.Format("{0}:{1}", email, ""));

                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

                string senderName = App.UserType == Helpers.Enums.UserType.Manager
                    ? string.Format("TEFL Account, Manager: {0}", App.ManagerProfile.DisplayNameEn)
                    : string.Format("TEFL Account, Student: {0} at {1}", App.StudentProfile.Name, App.ManagerProfile.DisplayNameEn);

                string emailBody = string.Format("<b>TEFL Software Support Request</b><br/><br/>{0}<br/><br/>{1}", senderName, ContactFormBox.Text);

                Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "emailBody", emailBody },
                { "senderName", senderName }
            };

                var json_data = await Functions.PostItem<JsonBasicResult<object>>("ConctactFormMessage", values);

                if (json_data.ok)
                {
                    ContactFormBox.Text = "";
                    ContactFormResult.Text = PageText.SuccessfullySent;
                }
                else
                {
                    ContactFormResult.Text = PageText.Failed;
                    Functions.ShowMessageDialog("Error!", json_data.message);
                }

                ContactFormBox.IsEnabled = true;
                SubmitBtn.IsEnabled = true;
            }
        }
    }

    public sealed partial class HelpPageText
    {
        #region Public Properties

        public string Help { get; set; }
        public string ContactMethods { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Wechat { get; set; }
        public string WechatQR { get; set; }
        public string ContactUs { get; set; }
        public string Submit { get; set; }
        public string SuccessfullySent { get; set; }
        public string Failed { get; set; }

        #endregion Public Properties
    }

    public sealed class HelpPageTextClass
    {
        #region Internal Fields

        internal static HelpPageText HelpPageTextEn = new HelpPageText
        {
            Help = "Help",
            ContactMethods = "Contact Methods",
            Email = "Email: ",
            Phone = "Phone: ",
            Wechat = "Wechat ID: ",
            WechatQR = "Wechat QR: ",
            ContactUs = "Contact Form",
            Submit = "Submit",
            SuccessfullySent = "Sent!",
            Failed = "Failed!"
        };

        internal static HelpPageText HelpPageTextZH = new HelpPageText
        {
            Help = "帮助",
            ContactMethods = "联系客服",
            Email = "e-mail: ",
            Phone = "电话: ",
            Wechat = "微信号: ",
            WechatQR = "微信二维码: ",
            ContactUs = "备注",
            Submit = "提交",
            SuccessfullySent = "发送成功!",
            Failed = "失败!"
        };

        #endregion Internal Fields
    }
}