using ExibitMeProject.Models;
using QRCoder;
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
    public partial class QuestionQrCodeGeneratorPage : ContentPage
    {
        public string QuestionString { get; set; }
        public QuestionQrCodeGeneratorPage()
        {
            InitializeComponent();
            string Q1String = QuestionEntry1.Text;
            string Q2String = QuestionEntry2.Text;
            string Q3String = QuestionEntry3.Text;
            QuestionString = "" + Q1String + ";" + Q2String + ";" + Q3String + "";
        }

        private void GenerateQrCodeButton_Clicked(object sender, EventArgs e)
        {
            Question question = new Question();
            question.QuestionBody1 = QuestionEntry1.Text;
            question.QuestionBody2 = QuestionEntry2.Text;
            question.QuestionBody3 = QuestionEntry3.Text;

            string serializedQuestion = Newtonsoft.Json.JsonConvert.SerializeObject(question);
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(serializedQuestion, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(100);
            QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }
    }
}