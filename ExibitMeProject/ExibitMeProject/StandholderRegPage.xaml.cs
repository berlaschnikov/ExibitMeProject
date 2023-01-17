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
	public partial class StandholderRegPage : ContentPage
	{
		public StandholderRegPage ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            using SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.Insert(new Standholder { Name = NameEntry.Text, Company = CompanyEntry.Text, Password = PasswordEntry.Text });
            Application.Current.Properties["Name"] = NameEntry.Text;
            Application.Current.Properties["Company"] = CompanyEntry.Text;
            Application.Current.Properties["Password"] = PasswordEntry.Text;
            DisplayAlert("", "Registration Succesful!", "OK");
            Xamarin.Essentials.Vibration.Vibrate(2000);
            Navigation.PushAsync(new StandholderLoginPage());
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}