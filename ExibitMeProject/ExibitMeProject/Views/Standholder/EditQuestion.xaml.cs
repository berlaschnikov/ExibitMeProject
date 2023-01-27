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
	public partial class EditQuestion : ContentPage
	{
        public Question selectedQuestion { get; set; }
        public EditQuestion (Question question)
		{
			InitializeComponent ();
			selectedQuestion = question;
            BindingContext = selectedQuestion;

            NameEntry.Text = selectedQuestion.Name;
            Question1Entry.Text = selectedQuestion.QuestionBody1;
            Question2Entry.Text = selectedQuestion.QuestionBody2;
            Question3Entry.Text = selectedQuestion.QuestionBody3;
        }
        
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            selectedQuestion.Name = NameEntry.Text;
            selectedQuestion.QuestionBody1 = Question1Entry.Text;
            selectedQuestion.QuestionBody2 = Question2Entry.Text;
            selectedQuestion.QuestionBody3 = Question3Entry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                updatedRows = sQLiteConnection.Update(selectedQuestion);
            }
            if (updatedRows > 0)
            {
                _ = DisplayAlert("Succes!", "Changes have been made.", "OK");
            }
            else
            {
                _ = DisplayAlert("Something went wrong", "Your info was not altered", "OK");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int deletedRows;
            selectedQuestion.Name = NameEntry.Text;
            selectedQuestion.QuestionBody1 = Question1Entry.Text;
            selectedQuestion.QuestionBody2 = Question2Entry.Text;
            selectedQuestion.QuestionBody3 = Question3Entry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                deletedRows = sQLiteConnection.Delete(selectedQuestion);
            }

            if (deletedRows > 0)
            {
                _ = DisplayAlert("Succes!", "You have deleted the question", "OK");
            }
            else
            {
                _ = DisplayAlert("Something went wrong", "Your question is not deleted", "OK");
            }

            await Navigation.PopAsync();
        }
    }
}