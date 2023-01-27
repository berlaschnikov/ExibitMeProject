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
    public partial class CreateUrl : ContentPage
    {
        public CreateUrl()
        {
            InitializeComponent();
        }

        private async void CreateButton_Clicked(object sender, EventArgs e)
        {
            Url url = new Url();
            url.Name = NameEntry.Text;
            url.UrlBody = UrlEntry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Url>();
            int insertedRows = sQLiteConnection.Insert(url);
            sQLiteConnection.Close();

            if (insertedRows > 0)
            {
                _ = DisplayAlert("Question Saved!", "Your question has been added to the database.", "Ok");
            }
            else
            {
                _ = DisplayAlert("Something went wrong!", "Your question has not been saved to the database.", "Ok");
            }
            await Navigation.PopAsync();
        }
    }
}