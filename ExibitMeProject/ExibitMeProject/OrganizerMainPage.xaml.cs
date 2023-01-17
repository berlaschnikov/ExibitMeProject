using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrganizerMainPage : ContentPage
    {
        public OrganizerMainPage()
        {
            InitializeComponent();
        }

        private void ViewRushButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RushPage());
        }

            public static void Main(string[] args)
            {
                var data = new[]
                {
                new { Date = new DateTime(2022, 1, 1), Value = 5 },
                new { Date = new DateTime(2022, 1, 2), Value = 6 },
                new { Date = new DateTime(2022, 2, 1), Value = 7 },
                new { Date = new DateTime(2022, 2, 2), Value = 8 },
                new { Date = new DateTime(2022, 3, 1), Value = 9 },
                new { Date = new DateTime(2022, 3, 2), Value = 10 },
            };  

                // Filter by month
                var januaryData = data.Where(x => x.Date.Month == 1);
                Console.WriteLine("Data for January: " + string.Join(", ", januaryData.Select(x => x.Value)));

                // Filter by week
                var firstWeekData = data.Where(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.Date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday) == 1);
                Console.WriteLine("Data for first week: " + string.Join(", ", firstWeekData.Select(x => x.Value)));

                // Filter by day
                var sundayData = data.Where(x => x.Date.DayOfWeek == DayOfWeek.Sunday);
                Console.WriteLine("Data for Sundays: " + string.Join(", ", sundayData.Select(x => x.Value)));
            }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            // Add your code here to handle the event when the picker's selected index changes
            var picker = sender as Picker;
            var selectedItem = picker.SelectedItem as string;
            // Do something with the selected item
        }
    }

}

