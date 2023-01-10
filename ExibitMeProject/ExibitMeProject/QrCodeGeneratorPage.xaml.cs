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
        public QrCodeGeneratorPage()
        {
            InitializeComponent();            
        }

        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.Q);
            //PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            //byte[] qrCodeBytes = qRCode.GetGraphic(20);
            //QrCodeImage = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string eccString = ECCLevelPicker.Items[ECCLevelPicker.SelectedIndex];
            if (eccString == "L")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText.Text, QRCodeGenerator.ECCLevel.L);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "M")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText.Text, QRCodeGenerator.ECCLevel.M);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "Q")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText.Text, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            else if (eccString == "H")
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText.Text, QRCodeGenerator.ECCLevel.H);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            }
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText.Text, QRCodeGenerator.ECCLevel.eccString);
            //var qrCode = new PngByteQRCode(qrCodeData);
            //byte[] imageByteArray = qrCode.GetGraphic(20);
            //QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(imageByteArray));
        }
    }
}