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
	public partial class VisitorRegPage : ContentPage
	{
		public VisitorRegPage ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            using SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.Insert(new Visitor { FullName = FullNameEntry.Text, EmailAddress = EmailAddressEntry.Text, Street = StreetEntry.Text, PostalCode = PostalCodeEntry.Text, City = CityEntry.Text, State = StateEntry .Text, Country = CountryEntry.Text, Phone = PhoneEntry.Text, Occupation = OccupationEntry.Text });
            Application.Current.Properties["FullName"] = FullNameEntry.Text;
            Application.Current.Properties["EmailAddress"] = EmailAddressEntry.Text;
            Application.Current.Properties["Street"] = StreetEntry.Text;
            Application.Current.Properties["PostalCode"] = PostalCodeEntry.Text;
            Application.Current.Properties["City"] = CityEntry.Text;
            Application.Current.Properties["State"] = StateEntry.Text;
            Application.Current.Properties["Country"] = CountryEntry.Text;
            Application.Current.Properties["Phone"] = PhoneEntry.Text;
            Application.Current.Properties["Occupation"] = OccupationEntry.Text;
            DisplayAlert("", "Registration Succesful!", "OK");
            Xamarin.Essentials.Vibration.Vibrate(2000);
            Navigation.PushAsync(new VisitorLoginPage());
        }
    

        private void BackButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}