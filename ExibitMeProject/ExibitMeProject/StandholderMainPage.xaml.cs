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
    public partial class StandholderMainPage : ContentPage
    {
        public StandholderMainPage()
        {
            InitializeComponent();
        }

        private void ViewReviewPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewReviewPage());
        }

        private void ViewVisitorPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewVisitorPage());
        }

        private void ViewTurnoverPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VIewTurnoverPage());
        }

        private void GoToQRPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QrCodeScannerPage());
        }
    }
}