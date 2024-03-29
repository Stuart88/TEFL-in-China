﻿using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using TEFL_App.Models;
using static TEFL_App.Helpers.Enums;
using static TEFL_App.Views.Student.StudentProfilePageTextClass;
using System.Diagnostics;

namespace TEFL_App.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentProfile.xaml
    /// </summary>
    public partial class StudentProfile : Page
    {
        #region Private Fields

        private readonly BitmapImage DefaultPic = new BitmapImage(new Uri(@"pack://application:,,,/TEFL_App;component/Assets/Images/CandidateDefault.png"));

        #endregion Private Fields

        #region Public Constructors

        public StudentProfile(TEFLProfile profile)
        {
            Profile = profile;

            if (DataLayer.DbContext.GetProfilePic(profile.ID, out DataLayer.DbProfilePic pic))
            {
                ProfilePic = Helpers.Functions.LoadImage(pic.ImageBytes);
            }
            else
            {
                ProfilePic = DefaultPic;
            }

            InitializeComponent();

            AssignModuleScoreLists(ModuleNum.Mod1, Profile.Mod1QuizScores.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray());
            AssignModuleScoreLists(ModuleNum.Mod2, Profile.Mod2QuizScores.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray());
            AssignModuleScoreLists(ModuleNum.Mod3, Profile.Mod3QuizScores.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray());
            AssignModuleScoreLists(ModuleNum.Mod4, Profile.Mod4QuizScores.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray());
            AssignModuleScoreLists(ModuleNum.FinalExam, Profile.ExamScores.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray());

            FinalExamPassedText.Content = Helpers.Functions.HighestExamScore(Profile.ExamScores) > Helpers.Globals.QuizScorePassMark
                ? PageText.Passed
                : "";

            if (Profile.LessonPlanSubmitted)
            {
                AssignmentText.Content = PageText.LessonPlanSubmitted;
                Button downloadBtn = new Button
                {
                    Content = PageText.Download,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Style = FindResource("MainButtonStyle") as Style,
                    Margin = new Thickness(0, 15, 0, 0),
                };
                downloadBtn.Click += DownloadAssignment;

                AssignmentStackPanel.Children.Add(downloadBtn);
            }
            else
            {
                AssignmentText.Content = PageText.LessonPlanNotSubmitted;
            }

            if (Profile.CertificateID > 0)
            {
                TEFlCertText.Content = PageText.TEFLCertificate;
            }
            else
            {
                TEFlCertText.Content = " - ";
            }
        }

        private void DownloadAssignment(object sender, EventArgs args)
        {
            try
            {
                Process.Start(new ProcessStartInfo(Profile.LessonPlanPath));
            }
            catch (Exception ex)
            {
                Helpers.Functions.ShowErrorMessageDialog(ex);
            };
        }



        public Visibility UserIsCandidate { get; set; } = App.UserType == Helpers.Enums.UserType.Candidate
                     ? Visibility.Visible
             : Visibility.Collapsed;

        public Visibility UserIsManager { get; set; } = App.UserType == Helpers.Enums.UserType.Manager
            ? Visibility.Visible
            : Visibility.Collapsed;

        #endregion Public Constructors

        #region Public Properties

        public StudentProfilePageText PageText { get; set; } = App.Settings.CultureInfo == Helpers.Enums.Language.English
                    ? StudentProfilePageTextEn
                    : StudentProfilePageTextZH;

        public TEFLProfile Profile { get; set; }
        public BitmapImage ProfilePic { get; set; }

        private void AssignModuleScoreLists(ModuleNum moduleNum, string[] scores)
        {


            string highestScore = scores.Length > 0
                ? string.Format("{0}: {1}%", PageText.HighestScore, Helpers.Functions.HighestExamScore(scores))
                : PageText.NoData;

            SolidColorBrush grey = new SolidColorBrush(Colors.DarkGray);
            ///Asign list header
            switch (moduleNum)
            {
                case ModuleNum.Mod1:
                    _ = Module1ScoresPanel.Children.Add(new TextBlock { Text = highestScore, Style = FindResource("ModuleScoresHeaderStyle") as Style });
                    _ = Module1ScoresPanel.Children.Add(new Frame { Height = 2, Background = grey,  Margin = new Thickness(0, 0, 0, 5) });
                    break;

                case ModuleNum.Mod2:
                    _ = Module2ScoresPanel.Children.Add(new TextBlock { Text = highestScore, Style = FindResource("ModuleScoresHeaderStyle") as Style });
                    _ = Module2ScoresPanel.Children.Add(new Frame { Height = 2, Background = grey, Margin = new Thickness(0, 0, 0, 5) });
                    break;

                case ModuleNum.Mod3:
                    _ = Module3ScoresPanel.Children.Add(new TextBlock { Text = highestScore, Style = FindResource("ModuleScoresHeaderStyle") as Style });
                    _ = Module3ScoresPanel.Children.Add(new Frame { Height = 2, Background = grey , Margin = new Thickness(0, 0, 0, 5) });
                    break;

                case ModuleNum.Mod4:
                    _ = Module4ScoresPanel.Children.Add(new TextBlock { Text = highestScore, Style = FindResource("ModuleScoresHeaderStyle") as Style });
                    _ = Module4ScoresPanel.Children.Add(new Frame { Height = 2, Background = grey , Margin = new Thickness(0, 0, 0, 5) });
                    break;
                case ModuleNum.FinalExam:
                    _ = FinalExamScoresPanel.Children.Add(new TextBlock { Text = highestScore, Style = FindResource("ModuleScoresHeaderStyle") as Style });
                    _ = FinalExamScoresPanel.Children.Add(new Frame { Height = 2, Background = grey, Margin = new Thickness(0, 0, 0, 5) });
                    break;
            }

            ///Assign list values
            foreach (string s in scores)
            {
                switch (moduleNum)
                {
                    case ModuleNum.Mod1:
                        _ = Module1ScoresPanel.Children.Add(new TextBlock { Text = s, TextAlignment = TextAlignment.Center });
                        break;

                    case ModuleNum.Mod2:
                        _ = Module2ScoresPanel.Children.Add(new TextBlock { Text = s, TextAlignment = TextAlignment.Center });
                        break;

                    case ModuleNum.Mod3:
                        _ = Module3ScoresPanel.Children.Add(new TextBlock { Text = s, TextAlignment = TextAlignment.Center });
                        break;

                    case ModuleNum.Mod4:
                        _ = Module4ScoresPanel.Children.Add(new TextBlock { Text = s, TextAlignment = TextAlignment.Center });
                        break;
                    case ModuleNum.FinalExam:
                        _ = FinalExamScoresPanel.Children.Add(new TextBlock { Text = s, TextAlignment = TextAlignment.Center });
                        break;
                }
            }
        }

        #endregion Public Properties

        #region Private Methods

        //private void ImgRemoveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if(MessageBox.Show(PageText.AreYouSure, PageText.RemoveImage, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
        //    {
        //        DataLayer.DbContext.DeleteProfilePic(Profile.ID);
        //        ProfilePic = DefaultPic;
        //        ProfilePicXAML.Source = DefaultPic;
        //    }
        //}

        //private void ImgSelectBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

        //    fileDialog.DefaultExt = ".png";
        //    fileDialog.Filter = "Image Files (*.bmp, *.jpg;*.png)|*.bmp;*.jpg;*.png";

        //    bool? result = fileDialog.ShowDialog();

        //    if (result == true)
        //    {
        //        BitmapImage newPic = new BitmapImage(new Uri(fileDialog.FileName));

        //        ProfilePic = newPic;
        //        ProfilePicXAML.Source = newPic;

        //        byte[] newPicBytes = Helpers.Functions.ImageToByteArray(newPic);

        //        if (DataLayer.DbContext.GetProfilePic(Profile.ID, out DataLayer.DbProfilePic oldImage))
        //        {
        //            oldImage.ImageBytes = newPicBytes;
        //            DataLayer.DbContext.UpdateProfilePic(oldImage);
        //        }
        //        else
        //        {
        //            DataLayer.DbProfilePic dbPic = new DataLayer.DbProfilePic
        //            {
        //                CandidateID = Profile.ID,
        //                ImageBytes = newPicBytes
        //            };

        //            DataLayer.DbContext.AddProfilePic(dbPic);
        //        }
        //    }
        //}

        #endregion Private Methods
    }

    public sealed partial class StudentProfilePageText
    {
        #region Public Properties

        public string AreYouSure { get; set; }
        public string ExamAttempts { get; set; }
        public string ExamScores { get; set; }
        public string FinalExam { get; set; }
        public string FinishDate { get; set; }
        public string HighestScore { get; set; }
        public string LessonPlanAssignment { get; set; }
        public string Module1 { get; set; }
        public string Module2 { get; set; }
        public string Module3 { get; set; }
        public string Module4 { get; set; }
        public string ModulesCompleted { get; set; }
        public string ModuleTestScores { get; set; }
        public string RemoveImage { get; set; }
        public string SelectImage { get; set; }
        public string StartDate { get; set; }
        public string StudentProfile { get; set; }
        public string TEFLCertificate { get; set; }
        public string Passed { get; set; }
        public string LessonPlanNotSubmitted { get; set; }
        public string LessonPlanSubmitted { get; set; }
        public string Download { get; set; }
        public string NoData { get; set; }

        #endregion Public Properties
    }

    public sealed class StudentProfilePageTextClass
    {
        #region Internal Fields

        internal static StudentProfilePageText StudentProfilePageTextEn = new StudentProfilePageText
        {
            SelectImage = "Select Image",
            RemoveImage = "Remove Image",
            AreYouSure = "Are you sure?",
            ExamAttempts = "Exam Attempts",
            ExamScores = "Exam Scores",
            FinishDate = "Finish Date",
            LessonPlanAssignment = "Assignment",
            LessonPlanNotSubmitted = "Not yet submitted",
            LessonPlanSubmitted = "Submitted",
            Download = "Download",
            ModulesCompleted = "Modules Completed",
            StartDate = "Start Date",
            StudentProfile = "Candidate Profile",
            FinalExam = "Final Exam",
            Module1 = "Module 1",
            Module2 = "Module 2",
            Module3 = "Module 3",
            Module4 = "Module 4",
            ModuleTestScores = "Module Test Scores",
            TEFLCertificate = "TEFL Certificate",
            HighestScore = "Highest Score",
            Passed = "- Passed ✔",
            NoData = "No Data"
        };

        internal static StudentProfilePageText StudentProfilePageTextZH = new StudentProfilePageText
        {
            SelectImage = "选择头像",
            RemoveImage = "删掉",
            AreYouSure = "确定？",
            ExamAttempts = "成绩详情",
            ExamScores = "结课成绩",
            FinishDate = "结课日期",
            LessonPlanAssignment = "已提交",
            LessonPlanNotSubmitted = "没提交",
            LessonPlanSubmitted = "已提交",
            Download = "下载",
            ModulesCompleted = "完成阶段",
            StartDate = "课程开始日期",
            StudentProfile = "学生档案",
            FinalExam = "最终成绩",
            Module1 = "阶段一",
            Module2 = "阶段二",
            Module3 = "阶段三",
            Module4 = "阶段四",
            ModuleTestScores = "课程阶段测试成绩",
            TEFLCertificate = "TEFL认证课程",
            HighestScore = "最高分",
            Passed = "- 已通过 ✔",
            NoData = "暂无数据"
        };

        #endregion Internal Fields
    }
}