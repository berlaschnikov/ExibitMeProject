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
            Standholder standholder = new Standholder();
            standholder.Name = NameEntry.Text;
            standholder.Company = CompanyEntry.Text;
            standholder.Password = PasswordEntry.Text;

            SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteconnection.CreateTable<Standholder>();
            int insertedRows = sQLiteconnection.Insert(standholder);
            sQLiteconnection.Close();

            if (insertedRows > 0)
            {
                _ = DisplayAlert("Gelukt", "Registratie gelukt", "Ok");
                Xamarin.Essentials.Vibration.Vibrate(500);
            }
            else
            {
                _ = DisplayAlert("Niet Gelukt", "Registratie mislukt", "Ok");
                Xamarin.Essentials.Vibration.Vibrate(500);
            }

            Navigation.PopAsync();

            //using SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            //sQLiteConnection.Insert(new Standholder { Name = NameEntry.Text, Company = CompanyEntry.Text, Password = PasswordEntry.Text });
            //Application.Current.Properties["Name"] = NameEntry.Text;
            //Application.Current.Properties["Company"] = CompanyEntry.Text;
            //Application.Current.Properties["Password"] = PasswordEntry.Text;
            //DisplayAlert("", "Registration Succesful!", "OK");
            //Xamarin.Essentials.Vibration.Vibrate(2000);
            //Navigation.PushAsync(new StandholderLoginPage());
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}