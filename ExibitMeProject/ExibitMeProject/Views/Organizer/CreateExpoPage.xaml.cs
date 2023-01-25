using ExibitMeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Organizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateExpoPage : ContentPage
    {
        public CreateExpoPage()
        {
            InitializeComponent();
        }

        private async void CreateButton_Clicked(object sender, EventArgs e)
        {
            Expo expo = new Expo();
            expo.Name = NameEntry.Text;
            expo.Location = LocationEntry.Text;
            expo.Date = DateEntry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Expo>();
            int insertedRows = sQLiteConnection.Insert(expo);
            sQLiteConnection.Close();

            if (insertedRows > 0)
            {
                DisplayAlert("Success", "Expo created successfully", "Ok");
            }
            else
            {
                DisplayAlert("Failure", "Expo failed to be created", "Ok");
            }
            await Navigation.PopAsync();
        }
    }
}