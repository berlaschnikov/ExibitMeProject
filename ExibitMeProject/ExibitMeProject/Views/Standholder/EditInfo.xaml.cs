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
	public partial class EditInfo : ContentPage
	{
        public Info selectedInfo { get; set; }
        public EditInfo (Info info)
		{
			InitializeComponent ();
            selectedInfo = info;
            BindingContext = selectedInfo;

            NameEntry.Text = selectedInfo.Name;
            InfoBodyEntry.Text = selectedInfo.InfoBody;
        }
        
        private async void EditInfoButton_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            selectedInfo.Name = NameEntry.Text;
            selectedInfo.InfoBody = InfoBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Info>();
                updatedRows = sQLiteConnection.Update(selectedInfo);
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

        private async void DeleteInfoButton_Clicked(object sender, EventArgs e)
        {
            int deletedRows;
            selectedInfo.Name = NameEntry.Text;
            selectedInfo.InfoBody = InfoBodyEntry.Text;


            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Info>();
                deletedRows = sQLiteConnection.Delete(selectedInfo);
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