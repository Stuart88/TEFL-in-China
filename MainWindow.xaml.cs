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

namespace TEFL_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            SetMainWindowContent(new Views.General.Login(SetMainWindowContent));
        }

        private void SetMainWindowContent(Page page)
        {
            Content = page;
        }
       
    }
}