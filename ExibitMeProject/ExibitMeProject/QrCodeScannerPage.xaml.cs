﻿using ExibitMeProject.Services;
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

        private async void ScanButton_Clicked(object sender, EventArgs e)
        {
			try
			{
				var scanner = DependencyService.Get<IQrScanningService>();
				var result = await scanner.ScanAsync();
				if (result != null)
				{
					TxtBarcode.Text = result;
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
    }
}