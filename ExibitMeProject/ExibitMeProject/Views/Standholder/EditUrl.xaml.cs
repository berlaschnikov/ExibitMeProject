using ExibitMeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Standholder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditUrl : ContentPage
	{
        public Url selectedUrl { get; set; }
        public EditUrl (Url url)
		{
			InitializeComponent ();
            selectedUrl = url;
            BindingContext = selectedUrl;

            NameEntry.Text = selectedUrl.Name;
            UrlEntry.Text = selectedUrl.UrlBody;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            selectedUrl.Name = NameEntry.Text;
            selectedUrl.UrlBody = UrlEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Url>();
                updatedRows = sQLiteConnection.Update(selectedUrl);
            }
            if (updatedRows > 0)
            {
                _ = DisplayAlert("Succes!", "Changes have been made.", "OK");
            }
            else
            {
                _ = DisplayAlert("Something went wrong", "Your info was not altered", "OK");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int deletedRows;
            selectedUrl.Name = NameEntry.Text;
            selectedUrl.UrlBody = UrlEntry.Text;


            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Url>();
                deletedRows = sQLiteConnection.Delete(selectedUrl);
            }

            if (deletedRows > 0)
            {
                _ = DisplayAlert("Succes!", "You have deleted the info", "OK");
            }
            else
            {
                _ = DisplayAlert("Something went wrong", "Your info is not deleted", "OK");
            }

            await Navigation.PopAsync();
        }
    }
}