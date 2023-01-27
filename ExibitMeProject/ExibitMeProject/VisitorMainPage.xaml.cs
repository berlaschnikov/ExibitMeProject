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
                    var convertable = JsonConvert.DeserializeObject(result);
                    if (convertable is Info) 
                    {
                        Info Ainfo = new Info();
                        Ainfo = (Info)convertable;
                        App.CurrentAppVisitor.InfoHistory.Add(Ainfo);
                    }
                    if (convertable is Question)
                    {
                        Question Aquestion = new Question();
                        Aquestion = (Question)convertable;
                        App.CurrentAppVisitor.QuestionHistory.Add(Aquestion);
                    }
                    if (result is Url)
                    {
                        Url Aurl = new Url();
                        Aurl = (Url)convertable;
                        App.CurrentAppVisitor.UrlHistory.Add(Aurl);
                        try
                        {
                            await Browser.OpenAsync(Aurl.UrlBody, BrowserLaunchMode.SystemPreferred);
                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Error", ex.Message, "Ok");
                            // An unexpected error occured. No browser may be installed on the device.
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Invalid QR code", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
                throw;
            }
        }
    }
}