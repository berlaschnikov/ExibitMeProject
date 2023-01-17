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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            bool isUsernameEmpty = string.IsNullOrEmpty(UsernameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);

            if (isUsernameEmpty)
            {
                UsernameEntry.Placeholder = "This can not be empty!";
                Xamarin.Essentials.Vibration.Vibrate(2000);
            }
            else if (isPasswordEmpty)
            {
                PasswordEntry.Placeholder = "This can not be empty";
                Xamarin.Essentials.Vibration.Vibrate(2000);
            }
            else
            {
                Navigation.PushAsync(new MainPage());
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegPage());
        }
    }
}