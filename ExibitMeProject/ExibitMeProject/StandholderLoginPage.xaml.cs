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
    public partial class StandholderLoginPage : ContentPage
    {
        public StandholderLoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StandholderRegPage());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            var standholder = sQLiteConnection.Table<Standholder>().Where(standholder => standholder.Name == UsernameEntry.Text && standholder.Password == PasswordEntry.Text).FirstOrDefault();
            if (standholder != null)
            {
                App.CurrentAppStandholder = standholder;
                DisplayAlert("Login Succesful!", "Welcome " + standholder.Name + "!", "OK");
                Xamarin.Essentials.Vibration.Vibrate(2000);
                Navigation.PushAsync(new StandholderMainPage());
            }
            else
            {
                DisplayAlert("", "Login Failed!", "OK");
                Xamarin.Essentials.Vibration.Vibrate(2000);
                return;
            }            
        }
    }
}