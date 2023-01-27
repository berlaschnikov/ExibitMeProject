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
    public partial class CreateInfo : ContentPage
    {
        public CreateInfo()
        {
            InitializeComponent();
        }
        
        private async void CreateInfoButton_Clicked(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Name = NameEntry.Text;
            info.InfoBody = InfoBodyEntry.Text;
            
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Info>();
            int insertedRows = sQLiteConnection.Insert(info);
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