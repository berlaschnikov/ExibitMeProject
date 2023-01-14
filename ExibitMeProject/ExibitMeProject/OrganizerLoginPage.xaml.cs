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
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            var organizer = sQLiteConnection.Table<Organizer>().Where(organizer => organizer.Name == UsernameEntry.Text && organizer.Password == PasswordEntry.Text).FirstOrDefault();
            if (organizer == null)
            {
                DisplayAlert("", "Login Failed!", "OK");
                Xamarin.Essentials.Vibration.Vibrate(2000);
                return;
            }
            App.CurrentAppOrganizer = organizer;
            DisplayAlert("Login Succesful!", "Welcome " + organizer.Name + "!", "OK");
            Xamarin.Essentials.Vibration.Vibrate(2000);
            Navigation.PushAsync(new OrganizerMainPage());
        }
    }
}