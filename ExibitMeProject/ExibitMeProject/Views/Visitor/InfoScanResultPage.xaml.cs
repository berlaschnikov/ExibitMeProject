using ExibitMeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Visitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScanResultPage : ContentPage
    {
        public InfoScanResultPage()
        {
            InitializeComponent();
        }
        public InfoScanResultPage(Info info)
        {
            InitializeComponent();
            InfoNameEntry.Text = info.Name;
            InfoEntry.Text = info.InfoBody;
        }
    }
}