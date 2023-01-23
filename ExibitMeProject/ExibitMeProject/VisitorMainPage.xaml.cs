using ExibitMeProject.Models;
using ExibitMeProject.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitorMainPage : ContentPage
    {
        public VisitorMainPage()
        {
            InitializeComponent();
        }

        private void GenerateQrCodeFullButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QrCodeGeneratorPage());
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage());
        }

        private async void ScanQrCodeButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    if(Uri.IsWellFormedUriString(result, UriKind.Absolute))
                    {
                        try
                        {
                            await Browser.OpenAsync(result, BrowserLaunchMode.SystemPreferred);
                        }
                        catch (Exception ex)
                        {
                            // An unexpected error occured. No browser may be installed on the device.
                        }
                    }
                    else
                    {
                        await Navigation.PushAsync(new Views.Visitor.VisitorScanResultPage(result));
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}