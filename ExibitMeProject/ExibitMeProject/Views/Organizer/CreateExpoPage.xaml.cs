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
            Expo expo = new()
            {
                Name = NameEntry.Text,
                Location = LocationEntry.Text,
                Date = DateEntry.Text,
                Organizer = App.CurrentAppOrganizer
            };

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Expo>();
            int insertedRows = sQLiteConnection.Insert(expo);
            sQLiteConnection.Close();

            if (insertedRows > 0)
            {
                await DisplayAlert("Success", "Expo created successfully", "Ok");
            }
            else
            {
                await DisplayAlert("Failure", "Expo failed to be created", "Ok");
            }
            await Navigation.PopAsync();
        }
    }
}