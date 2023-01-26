using ExibitMeProject.Models;
using SQLite;
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
    public partial class OrganizerLoginPage : ContentPage
    {
        public OrganizerLoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrganizerRegPage());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection sQLiteConnection = null;
            try
            {
                sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            }
            catch (SQLiteException ex)
            {
                DisplayAlert("Error", "Failed to connect to database: " + ex.Message, "OK");
                return;
            }

            if (sQLiteConnection.Table<Organizer>().Any())
            {
                var organizer = sQLiteConnection.Table<Organizer>().Where(organizer => organizer.Name == UsernameEntry.Text && organizer.Password == PasswordEntry.Text).FirstOrDefault();
                if (organizer != null)
                {
                    App.CurrentAppOrganizer = organizer;
                    DisplayAlert("Login Succesful!", "Welcome " + organizer.Name + "!", "OK");
                    Xamarin.Essentials.Vibration.Vibrate(500);
                    Navigation.PushAsync(new Views.Organizer.ChooseExpoPage());
                }
                else
                {
                    DisplayAlert("", "Login Failed", "OK");
                    Xamarin.Essentials.Vibration.Vibrate(500);
                    return;
                }
            }
            else
            {
                DisplayAlert("", "No organizer registered yet!", "OK");
                Xamarin.Essentials.Vibration.Vibrate(500);
            }
        }
    }
}