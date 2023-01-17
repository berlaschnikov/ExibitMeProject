
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using XFBarcode.Services;
using ZXing.Mobile;
using Xamarin.Forms;
using Android.Nfc.Tech;
using ExibitMeProject.Services;

[assembly: Dependency(typeof(XFBarcode.Droid.Services.QrScanningService))]

namespace XFBarcode.Droid.Services
{
	public class QrScanningService : IQrScanningService
	{
		public async Task<string> ScanAsync()
		{
			var optionsDefault = new MobileBarcodeScanningOptions();
			var optionsCustom = new MobileBarcodeScanningOptions();

			var scanner = new MobileBarcodeScanner()
			{
				TopText = "Scan the QR Code",
				BottomText = "Please Wait",
			};

			var scanResult = await scanner.Scan(optionsCustom);
			return scanResult.Text;
		}
	}
}
