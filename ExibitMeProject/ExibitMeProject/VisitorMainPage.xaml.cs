using ExibitMeProject.Models;
using ExibitMeProject.Services;
using ExibitMeProject.Views.Visitor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitorMainPage : ContentPage
    {
        public Visitor UpdatedVisitor { get; set; }
        public VisitorMainPage()
        {
            InitializeComponent();
            var currentVisitor = App.CurrentAppVisitor;
            UpdatedVisitor = currentVisitor;
        }

        private void GenerateQrCodeFullButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QrCodeGeneratorPage());
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage());
        }

        private async void ScanQrCodeButton_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<IQrScanningService>();
            var result = await scanner.ScanAsync();

            JObject jObject = JObject.Parse(result);
            
            if (jObject.ContainsKey("InfoBody"))
            {
                var info = JsonConvert.DeserializeObject<Info>(result);

                int updatedRows;
                if (UpdatedVisitor.InfoHistory == null) UpdatedVisitor.InfoHistory = new List<Info>();
                UpdatedVisitor.InfoHistory.Append<Info>(info);
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<Visitor>();
                    updatedRows = sQLiteConnection.Update(UpdatedVisitor);
                }
                App.CurrentAppVisitor.InfoHistory.Add(info);
                await Navigation.PushAsync(new InfoScanResultPage(info));
            }
            else if (jObject.ContainsKey("QuestionBody1"))
            {
                var question = JsonConvert.DeserializeObject<Question>(result);

                int updatedRows;
                if (UpdatedVisitor.QuestionHistory == null) UpdatedVisitor.QuestionHistory = new List<Question>();
                UpdatedVisitor.QuestionHistory.Append<Question>(question);
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<Visitor>();
                    updatedRows = sQLiteConnection.Update(UpdatedVisitor);
                }
                //App.CurrentAppVisitor.QuestionHistory.Add(question);
                await Navigation.PushAsync(new VisitorScanResultPage(question));
            }
            else if (jObject.ContainsKey("UrlBody"))
            {
                var url = JsonConvert.DeserializeObject<Url>(result);

                int updatedRows;
                if (UpdatedVisitor.UrlHistory == null) UpdatedVisitor.UrlHistory = new List<Url>();
                UpdatedVisitor.UrlHistory.Append<Url>(url);
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<Visitor>();
                    updatedRows = sQLiteConnection.Update(UpdatedVisitor);
                }
                App.CurrentAppVisitor.UrlHistory.Add(url);
                try
                {
                    await Browser.OpenAsync(url.UrlBody, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("error", ex.Message, "ok");
                    // an unexpected error occured. no browser may be installed on the device.
                }
            }
            else
            {
                await DisplayAlert("error", "invalid qr code", "ok");
            }
        }
    }
}
