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
	public partial class VisitorScanResultPage : ContentPage
	{
        public string Result { get; set; }
        public VisitorScanResultPage ()
		{
			InitializeComponent ();
		}
        public VisitorScanResultPage(string result)
        {
            InitializeComponent();
            Result = result;
            string[] seperateQuestion = result.Split(';');
            QuestionEntry1.Text = seperateQuestion[0];
            QuestionEntry2.Text = seperateQuestion[1];
            QuestionEntry3.Text = seperateQuestion[2];
        }

    }
}