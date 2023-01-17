using ExibitMeProject.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static Organizer CurrentAppOrganizer;
        public static Standholder CurrentAppStandholder;
        public static Visitor CurrentAppVisitor;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new UserPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            DatabaseLocation = databaseLocation;
            MainPage = new NavigationPage(new UserPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
