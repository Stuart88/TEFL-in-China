using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using TEFL_App.Models;

namespace TEFL_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string UserEmail { get; set; } = "";
        public static string UserPassword { get; set; } = "";

        public static readonly HttpClient client = new HttpClient();

        public static Employer ManagerProfile = new Employer();
        public static List<TEFLProfile> TEFLProfiles { get; set; }
    }
}
