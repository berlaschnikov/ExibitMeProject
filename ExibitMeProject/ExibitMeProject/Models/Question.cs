using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuestionBody1 { get; set; }
        public string QuestionBody2 { get; set; }
        public string QuestionBody3 { get; set; }

        public Question(int id, string questionBody1, string questionBody2, string questionBody3)
        {
            Id = id;
            QuestionBody1 = questionBody1;
            QuestionBody2 = questionBody2;
            QuestionBody3 = questionBody3;
        }
        public Question(string questionBody1, string questionBody2, string questionBody3)
        {
            QuestionBody1 = questionBody1;
            QuestionBody2 = questionBody2;
            QuestionBody3 = questionBody3;
        }
        public Question()
        {

        }
    }
}
