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
    public partial class StandholderLoginPage : ContentPage
    {
        public StandholderLoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StandholderRegPage());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StandholderMainPage());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}