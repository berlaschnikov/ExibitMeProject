using ExibitMeProject.Models;
using QRCoder;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Standholder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrlQrCodeGenPage : ContentPage
    {
        public Url SelectedUrl { get; set; }
        public UrlQrCodeGenPage()
        {
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Url>();
                var url = conn.Table<Url>().ToList();
                UrlListView.ItemsSource = url;
            }
        }

        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void GenQrButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectedUrl = (Url)button.CommandParameter;
            string serializedQuestion = Newtonsoft.Json.JsonConvert.SerializeObject(SelectedUrl);
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(serializedQuestion, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            CodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }

        private void CreateNewQuestionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUrl());
        }
        
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            SelectedUrl = (Url)viewCell.BindingContext;
        }

        private void UrlListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}