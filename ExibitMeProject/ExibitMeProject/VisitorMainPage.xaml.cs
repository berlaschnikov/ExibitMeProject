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
        private void TestButton_Clicked(object sender, EventArgs e)
        {
            
            TestEntry.Text = JsonConvert.SerializeObject(Visitor);
        }

        private void GenerateQrCodeFullButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QrCodeGeneratorPage(Visitor));
        }

        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage());
        }
    }
}