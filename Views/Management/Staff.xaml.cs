﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using static TEFL_App.Views.Management.StaffPageTextClass;

namespace TEFL_App.Views.Management
{
    /// <summary>
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : Page
    {
        public StaffPageText PageText { get; set; } = App.Settings.CultureInfo == Helpers.Enums.Language.English
            ? StaffPageTextEN
            : StaffPageTextZH;

        public Staff()
        {
            InitializeComponent();

            FillTableView();
        }

        private void FillTableView()
        {

            int rowIndex = 1;

            foreach(var p in App.TEFLProfiles)
            {
                staffGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                TextBlock nameText = new TextBlock
                {
                    Text = p.Name,
                    Style = Application.Current.FindResource("TableRowStylePlain") as Style,
                };
                Button actionBtn = new Button { Content = "Data" };
                TextBlock lastLoginText = new TextBlock
                {
                    Text = p.LastLogin.HasValue ? p.LastLogin.Value.ToString(App.CultureInfo) : "",
                    Style = Application.Current.FindResource("TableRowStylePlain") as Style,
                };
                TextBlock mod1Text = new TextBlock
                {
                    Text = Helpers.Functions.PassedQuiz(p.Mod1QuizScores) ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock mod2Text = new TextBlock
                {
                    Text = Helpers.Functions.PassedQuiz(p.Mod2QuizScores) ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock mod3Text = new TextBlock
                {
                    Text = Helpers.Functions.PassedQuiz(p.Mod3QuizScores) ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock mod4Text = new TextBlock
                {
                    Text = Helpers.Functions.PassedQuiz(p.Mod4QuizScores) ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock finalExamText = new TextBlock
                {
                    Text = Helpers.Functions.PassedQuiz(p.ExamScores) ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock assignmentText = new TextBlock
                {
                    Text = p.LessonPlanSubmitted ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock passedText = new TextBlock
                {
                    Text = p.CompletionDate.HasValue ? "✔" : "",
                    Style = Application.Current.FindResource("TableRowStyleGreenCheck") as Style,
                };
                TextBlock passDateText = new TextBlock
                {
                    Text = p.CompletionDate.HasValue ? p.CompletionDate.Value.ToString(App.CultureInfo) : "",
                    Style = Application.Current.FindResource("TableRowStylePlain") as Style,
                };

                staffGrid.Children.Add(nameText);
                staffGrid.Children.Add(actionBtn);
                staffGrid.Children.Add(lastLoginText);
                staffGrid.Children.Add(mod1Text);
                staffGrid.Children.Add(mod2Text);
                staffGrid.Children.Add(mod3Text);
                staffGrid.Children.Add(mod4Text);
                staffGrid.Children.Add(finalExamText);
                staffGrid.Children.Add(assignmentText);
                staffGrid.Children.Add(passedText);
                staffGrid.Children.Add(passDateText);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, rowIndex);

                Grid.SetColumn(actionBtn, 1);
                Grid.SetRow(actionBtn, rowIndex);

                Grid.SetColumn(lastLoginText, 2);
                Grid.SetRow(lastLoginText, rowIndex);
                
                Grid.SetColumn(mod1Text, 3);
                Grid.SetRow(mod1Text, rowIndex);
                
                Grid.SetColumn(mod2Text, 4);
                Grid.SetRow(mod2Text, rowIndex);
                
                Grid.SetColumn(mod3Text, 5);
                Grid.SetRow(mod3Text, rowIndex);
                
                Grid.SetColumn(mod4Text, 6);
                Grid.SetRow(mod4Text, rowIndex);
                
                Grid.SetColumn(finalExamText, 7);
                Grid.SetRow(finalExamText, rowIndex);
                
                Grid.SetColumn(assignmentText, 8);
                Grid.SetRow(assignmentText, rowIndex);
                
                Grid.SetColumn(passedText, 9);
                Grid.SetRow(passedText, rowIndex);
                
                Grid.SetColumn(passDateText, 10);
                Grid.SetRow(passDateText, rowIndex);

                

                rowIndex++;
            }
        }
    }

   

    public sealed class StaffPageTextClass
    {
        internal static StaffPageText StaffPageTextEN = new StaffPageText
        {
            Name = "Name",
            LastLogin = "Last Login",
            Module1 = "Mod 1",
            Module2 = "Mod 2",
            Module3 = "Mod 3",
            Module4 = "Mod 4",
            FinalExam = "Final Exam",
            Assignment = "Assignment",
            Passed = "Passed",
            PassDate = "Pass Date",
        };

        internal static StaffPageText StaffPageTextZH = new StaffPageText
        {
            Name = "名字",
            LastLogin = "最近登录",
            Module1 = "Mod 1",
            Module2 = "Mod 2",
            Module3 = "Mod 3",
            Module4 = "Mod 4",
            FinalExam = "考试",
            Assignment = "功课",
            Passed = "已通过",
            PassDate = "通过日期",
        };

        public class StaffPageText
        {
            public string Name { get; set; }
            public string LastLogin { get; set; }
            public string Module1 { get; set; }
            public string Module2 { get; set; }
            public string Module3 { get; set; }
            public string Module4 { get; set; }
            public string FinalExam { get; set; }
            public string Assignment { get; set; }
            public string Passed { get; set; }
            public string PassDate { get; set; }

        }
    }
}