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
	public partial class VisitorScanResultPage : ContentPage
	{
        public string Result { get; set; }
        public VisitorScanResultPage ()
		{
			InitializeComponent ();
		}
        
        public VisitorScanResultPage(Question question)
        {
            InitializeComponent();
            QuestionEntry1.Text = question.QuestionBody1;
            QuestionEntry2.Text = question.QuestionBody2;
            QuestionEntry3.Text = question.QuestionBody3;
        }
    }
}