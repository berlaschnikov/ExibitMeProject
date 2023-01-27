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
        public Question SelectedQuestion { get; set; }
        public QuestionQrCodeGeneratorPage()
        {
            InitializeComponent();            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Question>();
                var questions = conn.Table<Question>().ToList();
                QuestionListView.ItemsSource = questions;
            }
        }
        private void CreateNewUrlButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateQuestion());
        }

        private void GenQrButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            SelectedQuestion = (Question)button.CommandParameter;
            string serializedQuestion = Newtonsoft.Json.JsonConvert.SerializeObject(SelectedQuestion);
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(serializedQuestion, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(100);
            CodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            SelectedQuestion = (Question)viewCell.BindingContext;
        }

        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}