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
	public partial class QrCodeScannerPage : ContentPage
	{
		public QrCodeScannerPage ()
		{
			InitializeComponent ();
		}
	}
}