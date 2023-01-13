using ExibitMeProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitorMainPage : ContentPage
    {
        public Visitor Visitor;
        public VisitorMainPage()
        {
            InitializeComponent();
        }
        public VisitorMainPage(Visitor CurrentVisitor)
        {
            InitializeComponent();
            Visitor = CurrentVisitor;
        }

        private void GenerateQrCodeFullButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QrCodeGeneratorPage(Visitor));
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage());
        }

        private void ScanQrCodeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Visitor.VisitorQrCodeScannerPage());
        }
    }
}