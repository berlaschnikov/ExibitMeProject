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
    public partial class EditExpoPage : ContentPage
    {
        public Expo CurrentExpo { get; set; }
        public EditExpoPage(Expo selectedExpo)
        {
            InitializeComponent();
            CurrentExpo = selectedExpo;

            NameEntry.Text = CurrentExpo.Name;
            LocationEntry.Text = CurrentExpo.Location;
            DateEntry.Text = CurrentExpo.Date;
        }
        public EditExpoPage()
        {
            InitializeComponent();
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            CurrentExpo.Name = NameEntry.Text;
            CurrentExpo.Location = LocationEntry.Text;
            CurrentExpo.Date = DateEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Expo>();
                updatedRows = sQLiteConnection.Update(CurrentExpo);
            }
            
            if (updatedRows > 0)
            {
                _ = DisplayAlert("Succes!", "Changes have been made.", "OK");
            }
            else
            {
                _ = DisplayAlert("Something went wrong", "Your expo has not been altered", "OK");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int deletedRows;
            CurrentExpo.Name = NameEntry.Text;

            using (SQLiteConnection sQLiteConnection = new (App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Expo>();
                deletedRows = sQLiteConnection.Delete(CurrentExpo);
            }

            if (deletedRows > 0)
            {
                _ = DisplayAlert("Succes!", "You have deleted the question", "OK");
            }
            else
            {
                _ = DisplayAlert("Something went wrong", "Your question is not deleted", "OK");
            }

            await Navigation.PopAsync();
        }
    }
}