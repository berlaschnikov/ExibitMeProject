﻿using ExibitMeProject.Views.Standholder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StandholderMainPage : ContentPage
    {
        public StandholderMainPage()
        {
            InitializeComponent();
        }

        private void ViewReviewPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewReviewPage());
        }

        private void ViewTurnoverPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VIewTurnoverPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChooseGenPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeadsPage());
        }
    }
}