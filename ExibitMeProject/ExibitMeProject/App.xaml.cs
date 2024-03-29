﻿using ExibitMeProject.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static Organizer CurrentAppOrganizer { get; set; }
        public static Standholder CurrentAppStandholder { get; set; }
        public static Visitor CurrentAppVisitor { get; set; }
        public static Expo CurrentAppExpo;
        public static Info CurrentAppInfo;
        public static Question CurrentAppQuestion;
        public static Url CurrentAppUrl;
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
            //App.CurrentAppVisitor = null;
            //App.CurrentAppStandholder = null;
            //App.CurrentAppOrganizer = null;
        }

        protected override void OnResume()
        {
        }
    }
}
