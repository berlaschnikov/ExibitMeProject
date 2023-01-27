using ExibitMeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExibitMeProject.Views.Standholder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateQuestion : ContentPage
    {
        public CreateQuestion()
        {
            InitializeComponent();
        }

        private async void CreateButton_Clicked(object sender, EventArgs e)
        {
            Question question = new Question();
            question.Name = NameEntry.Text;
            question.QuestionBody1 = Question1Entry.Text;
            question.QuestionBody2 = Question2Entry.Text;
            question.QuestionBody3 = Question3Entry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Question>();
            int insertedRows = sQLiteConnection.Insert(question);
            sQLiteConnection.Close();

            if (insertedRows > 0)
            {
                _ = DisplayAlert("Question Saved!", "Your question has been added to the database.", "Ok");
            }
            else
            {
                _ = DisplayAlert("Something went wrong!", "Your question has not been saved to the database.", "Ok");
            }
            await Navigation.PopAsync();
        }
    }
}