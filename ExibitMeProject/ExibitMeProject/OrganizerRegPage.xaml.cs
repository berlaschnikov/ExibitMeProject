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
            Organizer organizer = new Organizer();
            organizer.Name = NameEntry.Text;
            organizer.Organisation = OrganisationEntry.Text;
            organizer.Password = PasswordEntry.Text;

            SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteconnection.CreateTable<Organizer>();
            int insertedRows = sQLiteconnection.Insert(organizer);
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
            //sQLiteConnection.Insert(new Organizer { Name = NameEntry.Text, Organisation = OrganisationEntry.Text, Password = PasswordEntry.Text });
            //Application.Current.Properties["Name"] = NameEntry.Text;
            //Application.Current.Properties["Organisation"] = OrganisationEntry.Text;
            //Application.Current.Properties["Password"] = PasswordEntry.Text;
            //DisplayAlert("", "Registration Succesful!", "OK");
            //Xamarin.Essentials.Vibration.Vibrate(2000);
            //Navigation.PushAsync(new OrganizerLoginPage());
        }

        
    }
}