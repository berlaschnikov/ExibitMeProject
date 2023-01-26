using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExibitMeProject.Models;

namespace ExibitMeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrganizerMainPage : ContentPage
    {
        public Expo CurrentExpo { get; set; }
        public OrganizerMainPage(Expo selectedExpo)
        {
            CurrentExpo = selectedExpo;
            InitializeComponent();
        }

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

            var morningData = data.Where(x => x.Date.Hour >= 6 && x.Date.Hour < 12);
            Console.WriteLine("Data for morning: " + string.Join(", ", morningData.Select(x => x.Value)));

            var afternoonData = data.Where(x => x.Date.Hour >= 12 && x.Date.Hour < 18);
            Console.WriteLine("Data for afternoon: " + string.Join(", ", afternoonData.Select(x => x.Value)));

            var eveningData = data.Where(x => x.Date.Hour >= 18 && x.Date.Hour < 24);
            Console.WriteLine("Data for evening: " + string.Join(", ", eveningData.Select(x => x.Value)));

            var specificHourData = data.Where(x => x.Date.Hour == 14);
            Console.WriteLine("Data for 14:00: " + string.Join(", ", specificHourData.Select(x => x.Value)));

            var specificDayData = data.Where(x => x.Date.DayOfWeek == DayOfWeek.Wednesday);
            Console.WriteLine("Data for Wednesday: " + string.Join(", ", specificDayData.Select(x => x.Value)));
        }

        public void OnFilterChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            int selectedIndex = picker.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    // code to filter data by hour
                    break;
                case 1:
                    // code to filter data by day
                    break;
            }
        }

    }
}

  


