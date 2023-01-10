using ExibitMeProject.Models;
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
        public VisitorMainPage()
        {
            InitializeComponent();
        }

        private void TestButton_Clicked(object sender, EventArgs e)
        {
            Visitor visitor = new Visitor();
            visitor.Id = 420;
            visitor.FullName = "Fulgencio Garcia Guzman";
            visitor.EmailAddress = "Guzman123@gmail.com";
            visitor.Street = "Langebaan 123";
            visitor.PostalCode= "12345";
            visitor.City = "Rotterdam";
            visitor.State = "Noord-Holland";
            visitor.Country = "Netherlands";
            visitor.Phone = "06-12345678";
            visitor.Occupation = "Hosselaar";
            TestEntry.Text = visitor.VisitorToStringFull();
        }
    }
}