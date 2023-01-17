﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrganizerMainPage : ContentPage
    {
        public OrganizerMainPage()
        {
            InitializeComponent();
        }

        private void ViewRushButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RushPage());
        }
    }
}