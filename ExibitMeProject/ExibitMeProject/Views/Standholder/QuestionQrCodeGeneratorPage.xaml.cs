using QRCoder;
using System;
using System.Collections.Generic;
using QRCoder;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Standholder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]    
    public partial class QuestionQrCodeGeneratorPage : ContentPage
    {
        public string QuestionString { get; set; }
        public QuestionQrCodeGeneratorPage()
        {
            InitializeComponent();
            QuestionString = "" + QuestionEntry1 + "," + QuestionEntry2 + "," + QuestionEntry3;
        }

        private void GenerateQrCodeButton_Clicked(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string eccString = ECCLevelPicker.Items[ECCLevelPicker.SelectedIndex];
            if (eccString == "L")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QuestionString, QRCodeGenerator.ECCLevel.L);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "M")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QuestionString, QRCodeGenerator.ECCLevel.M);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "Q")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QuestionString, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "H")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QuestionString, QRCodeGenerator.ECCLevel.H);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
        }
    }
}