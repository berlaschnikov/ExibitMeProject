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
        Visitor Visitor;
        public QrCodeGeneratorPage()
        {
            InitializeComponent();            
        }
        public QrCodeGeneratorPage(Visitor CurrentVisitor)
        {
            InitializeComponent();
            Visitor = CurrentVisitor;
            VisitorString = JsonConvert.SerializeObject(Visitor);
        }

        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string eccString = ECCLevelPicker.Items[ECCLevelPicker.SelectedIndex];
            if (eccString == "L")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(VisitorString, QRCodeGenerator.ECCLevel.L);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "M")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(VisitorString, QRCodeGenerator.ECCLevel.M);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "Q")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(VisitorString, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "H")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(VisitorString, QRCodeGenerator.ECCLevel.H);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
        }
    }
}