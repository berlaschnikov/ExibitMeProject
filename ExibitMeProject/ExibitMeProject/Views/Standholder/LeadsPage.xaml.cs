using ExibitMeProject.Services;
using ExibitMeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace ExibitMeProject.Views.Standholder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LeadsPage : ContentPage
	{
        public Models.Standholder UpdatedStandholder { get; set; }
        public LeadsPage ()
		{
			InitializeComponent ();
            var currenStandholder = App.CurrentAppStandholder;
            UpdatedStandholder = currenStandholder;
            LeadsListView.ItemsSource = UpdatedStandholder.Leads;
        }

        private async void ScanLeadsButton_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<IQrScanningService>();
            var result = await scanner.ScanAsync();
            var info = JsonConvert.DeserializeObject<Models.Visitor>(result);
            UpdatedStandholder.Leads.Add(info);
            int updatedRows;
			try
			{
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<Models.Standholder>();                    
                    updatedRows = sQLiteConnection.Update(info);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}