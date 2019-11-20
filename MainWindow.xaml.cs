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

            Loaded += async (s, a) =>
            {
                if (await GetVersionNumber() > App.VersionNumber)
                {
                    SetMainWindowContent(new Views.General.PleaseUpdate());

                }
                else
                {
                    SetMainWindowContent(new Views.General.Login(SetMainWindowContent));
                }
            };
        }

        private void SetMainWindowContent(Page page)
        {
            Content = page;
        }

        private async Task<int> GetVersionNumber()
        {
            string json_data = await App.client.GetStringAsync(Globals.baseURL + "GetAppVersion");

            if (!string.IsNullOrEmpty(json_data))
            {
                return JsonConvert.DeserializeObject<VersionResult>(json_data).version;
            }
            else
            {
                return int.MaxValue;
            }

        }
       
       public class VersionResult
        {
            public int version { get; set; }
        }
    }
}