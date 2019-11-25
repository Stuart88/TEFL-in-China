using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace TEFL_App.Views.Course
{
    /// <summary>
    /// Interaction logic for LessonPlanPage.xaml
    /// </summary>
    public partial class LessonPlanPage : Page
    {
        private Models.TEFLLessonPlanAttachment AttachmentToUpload;
        public bool CanUploadLessonPlan { get; set; } = Functions.HighestExamScore(App.StudentProfile.ExamScores) >= Globals.QuizScorePassMark;
        public LessonPlanPage()
        {
            InitializeComponent();

            LessonPlanInfoCanUpload.Visibility = CanUploadLessonPlan
                ? Visibility.Visible
                : Visibility.Collapsed;

            LessonPlanUploadArea.Visibility = CanUploadLessonPlan
               ? Visibility.Visible
               : Visibility.Collapsed;

            CannotUploadInfoText.Visibility = CanUploadLessonPlan
                ? Visibility.Collapsed
                : Visibility.Visible;

            DownloadButtonStackPanel.Visibility = App.StudentProfile.LessonPlanSubmitted
               ? Visibility.Visible
               : Visibility.Collapsed;

            AttachmentToUpload = new Models.TEFLLessonPlanAttachment
            {
                TEFLProfileID = App.StudentProfile.ID,
            };
        }


        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void FileSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = ".doc";
            fileDialog.Filter = "Documents (*.pdf;*.doc;*.docx;*ppt;*.pub;*.pubx)|*.pdf;*.doc;*.docx;*.ppt;*.pub;*.pubx";

            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                AttachmentToUpload.file = File.ReadAllBytes(fileDialog.FileName);
                AttachmentToUpload.FileType = Path.GetExtension(fileDialog.FileName);
                AttachmentToUpload.FileName = Path.GetFileNameWithoutExtension(fileDialog.FileName);

                UploadBtn.Visibility = Visibility.Visible;
                SelectedFileData.Text = string.Format("{0}", fileDialog.FileName);
            }
        }

        private async void UploadBtn_Click(object sender, RoutedEventArgs e)
        {
            SuccessMessage.Text = "Uploading...";

            AttachmentToUpload.CreationDate = DateTime.Now;
          
            string userData = Functions.Base64Encode(string.Format("{0};{1}:{2}", App.ManagerProfile.ID, App.UserLogin, App.UserPassword));
            App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userData);

            var result = await Functions.MultipartUpload<Models.TEFLLessonPlanAttachment>("PostLessonPlan", AttachmentToUpload.ConvertToDict());

            if (result.ok)
            {
                App.StudentProfile.LessonPlanPath = result.data.WebLocation;
                App.StudentProfile.LessonPlanSubmitted = true;
                SuccessMessage.Text = "Complete!";
                DownloadButtonStackPanel.Visibility = Visibility.Visible;
                UploadBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                SuccessMessage.Text = result.message;
            }
        }

        private void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(App.StudentProfile.LessonPlanPath));
            }
            catch (Exception ex)
            {
                Helpers.Functions.ShowErrorMessageDialog(ex);
            };
        }
    }
}
