using ExibitMeProject.Models;
using SQLite;
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
	public partial class HistoryPage : ContentPage
	{
		public Visitor CurrentVisitor { get; set; }
        public Visitor UpdatedVisitor { get; set; }
        public HistoryPage()
        {
            InitializeComponent();
            var currentAVisitor = App.CurrentAppVisitor;
            CurrentVisitor = currentAVisitor;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection sQLiteConnection = new (App.DatabaseLocation))
            {
                UpdatedVisitor = sQLiteConnection.Table<Visitor>().Where(v => v.Id == CurrentVisitor.Id).FirstOrDefault();
            }

            if (CurrentVisitor != null)
            {
                if (CurrentVisitor.InfoHistory != null)
                    InfoListView.ItemsSource = CurrentVisitor.InfoHistory;
                if (CurrentVisitor.QuestionHistory != null)
                    QuestionListView.ItemsSource = CurrentVisitor.QuestionHistory;
                if (CurrentVisitor.UrlHistory != null)
                    UrlListView.ItemsSource = CurrentVisitor.UrlHistory;
            }
            else
            {
                // Handle the case where CurrentVisitor is null
                await DisplayAlert("Error", "CurrentVisitor is null", "Ok");
            }
        }        
    }
}
