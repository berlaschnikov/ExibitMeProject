using ExibitMeProject.Models;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrCodeGeneratorPage : ContentPage
    {
        public string VisitorString { get; set; }
        public QrCodeGeneratorPage()
        {
            InitializeComponent();
            VisitorString = JsonConvert.SerializeObject(App.CurrentAppVisitor);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(VisitorString, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }

        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            OnAppearing();
        }
    }
}