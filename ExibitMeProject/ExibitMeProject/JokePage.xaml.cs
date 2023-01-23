using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokePage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        private Label _jokeLabel;
        private ProgressBar LoadingBar;
        double progress = 1;
        bool _isRunning;

        public JokePage()
        {
            InitializeComponent();
            LoadingBar = new ProgressBar
            {
                Progress = 1,
                HeightRequest = 20,
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            _jokeLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = new StackLayout
            {
                Children = { LoadingBar, _jokeLabel }
            };

            _isRunning = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (progress <= 0)
                {
                    _isRunning = false;
                    Navigation.PushAsync(new VisitorMainPage());
                }
                else
                {
                    progress -= 0.1;
                    LoadingBar.Progress = progress;
                }
                return _isRunning;
            });
            GetJoke();
        }

        private async void GetJoke()
        {
            var response = await _client.GetAsync("https://jokeapi.dev/joke/Any");
            var joke = await response.Content.ReadAsStringAsync();

            var jokeModel = JsonConvert.DeserializeObject<JokeModel>(joke);
            _jokeLabel.Text = jokeModel.joke;
        }
    }

    public class JokeModel
    {
        public string setup { get; set; }
        public string delivery { get; set; }
        public string joke { get { return $"{setup} \n {delivery}"; } }
    }
}