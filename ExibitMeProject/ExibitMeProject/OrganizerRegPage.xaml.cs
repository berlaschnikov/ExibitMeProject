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
	public partial class OrganizerRegPage : ContentPage
	{
		public OrganizerRegPage ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            using SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.Insert(new Organizer { Name = NameEntry.Text, Organisation = OrganisationEntry.Text });
            Application.Current.Properties["Name"] = NameEntry.Text;
            Application.Current.Properties["Organisation"] = OrganisationEntry.Text;
            DisplayAlert("", "Registration Succesful!", "OK");
            Xamarin.Essentials.Vibration.Vibrate(2000);
            Navigation.PushAsync(new OrganizerLoginPage());
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}