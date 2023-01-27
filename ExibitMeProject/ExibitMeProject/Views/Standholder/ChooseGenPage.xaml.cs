using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Standholder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseGenPage : ContentPage
    {
        public ChooseGenPage()
        {
            InitializeComponent();
        }

        private void InfoButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoQrCodeGenPage());
        }

        private void QuestionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestionQrCodeGeneratorPage());
        }

        private void UrlButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UrlQrCodeGenPage());
        }
    }
}