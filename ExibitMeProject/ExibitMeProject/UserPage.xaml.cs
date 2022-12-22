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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void VisitorButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitorLoginPage());
        }

        private void StandholderButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StandholderLoginPage());
        }

        private void OrganizerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrganizerLoginPage());
        }

        private void QrTestButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QrCodeGeneratorPage());
        }
    }
}