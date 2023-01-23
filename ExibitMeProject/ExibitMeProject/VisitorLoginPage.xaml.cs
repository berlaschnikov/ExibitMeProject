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
    public partial class VisitorLoginPage : ContentPage
    {
        //Visitor Visitor;
        public VisitorLoginPage()
        {
            InitializeComponent();
            //Visitor visitor = new Visitor
            //{
            //    Id = 420,
            //    FullName = "Fulgencio Garcia Guzman",
            //    EmailAddress = "Guzman123@gmail.com",
            //    Street = "Langebaan 123",
            //    PostalCode = "12345",
            //    City = "Rotterdam",
            //    State = "Noord-Holland",
            //    Country = "Netherlands",
            //    Phone = "06-12345678",
            //    Occupation = "Hosselaar"
            //};
            //Visitor = visitor;
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            var visitor = sQLiteConnection.Table<Visitor>().Where(visitor => visitor.EmailAddress == EmailEntry.Text && visitor.Password == PasswordEntry.Text).FirstOrDefault();
            if (visitor != null)
            {
                App.CurrentAppVisitor = visitor;
                DisplayAlert("Login Succesful!", "Welcome " + visitor.EmailAddress + "!", "OK");
                Xamarin.Essentials.Vibration.Vibrate(500);
                Navigation.PushAsync(new VisitorMainPage());
            }
            else
            {
                DisplayAlert("", "Login Failed!", "OK");
                Xamarin.Essentials.Vibration.Vibrate(500);
                return;
            }            
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitorRegPage());
        }
    }
}