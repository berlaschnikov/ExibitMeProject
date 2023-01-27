using ExibitMeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Organizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseExpoPage : ContentPage
    {
        public Expo selectedExpo { get; set; }
        public List<Expo> ExpoList { get; set; }
        public ChooseExpoPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Expo>();
                ExpoList = sQLiteConnection.Table<Expo>().ToList();
                ExhibitionList.ItemsSource = ExpoList;
            }
        }

        private void AddExpo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateExpoPage());
        }

        private void ExhibitionList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedExpo = ExhibitionList.SelectedItem as Expo;
            Navigation.PushAsync(new OrganizerMainPage(selectedExpo));
        }

        private void EditExpoPage_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            selectedExpo = (Expo)button.CommandParameter;
            Navigation.PushAsync(new EditExpoPage(selectedExpo));
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            selectedExpo = (Expo)viewCell.BindingContext;
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}