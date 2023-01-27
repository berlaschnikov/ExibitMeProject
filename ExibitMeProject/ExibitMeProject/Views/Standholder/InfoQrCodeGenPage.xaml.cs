using ExibitMeProject.Models;
using QRCoder;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Standholder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoQrCodeGenPage : ContentPage
    {
        public Info SelectedInfo { get; set; }
        public InfoQrCodeGenPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Info>();
                var infos = conn.Table<Info>().ToList();
                InfoListView.ItemsSource = infos;
            }
        }

        private void CreateNewInfoButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateInfo());
        }

        private void InfoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
        
        private void GenQrButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectedInfo = (Info)button.CommandParameter;
            string serializedQuestion = Newtonsoft.Json.JsonConvert.SerializeObject(SelectedInfo);
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(serializedQuestion, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(100);
            CodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));            
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            SelectedInfo = (Info)viewCell.BindingContext;
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}