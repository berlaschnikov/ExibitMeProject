using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Visitor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(120)]
        public string FullName { get; set; }
        [MaxLength(75)]
        public string EmailAddress { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
        [MaxLength(90)]
        public string Street { get; set; }
        [MaxLength(11)]
        public string PostalCode { get; set; }
        [MaxLength(45)]
        public string City { get; set; }
        [MaxLength(28)]
        public string State { get; set; }
        [MaxLength(56)]
        public string Country { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Occupation { get; set; }
        [TextBlob("HistoryBlobbed")]
        public List<Info> InfoHistory { get; set; }
        [TextBlob("HistoryBlobbed")]
        public List<Question> QuestionHistory { get; set; }
        [TextBlob("HistoryBlobbed")]
        public List<Url> UrlHistory { get; set; }

        public Visitor(int id, string fullName, string emailAddress, string password, string street, string postalCode, string city, string state, string country, string phone, string occupation)
        {
            Id = id;
            FullName = fullName;
            EmailAddress = emailAddress;
            Password = password;
            Street = street;
            PostalCode = postalCode;
            City = city;
            State = state;
            Country = country;
            Phone = phone;
            Occupation = occupation;
        }

        public Visitor(string fullName, string emailAddress, string password, string street, string postalCode, string city, string state, string country, string phone, string occupation)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            Password = password;
            Street = street;
            PostalCode = postalCode;
            City = city;
            State = state;
            Country = country;
            Phone = phone;
            Occupation = occupation;
        }

        public Visitor()
        {
            
        } 
        
        public void AddInfoHistory(object passedHistory)
        {
            InfoHistory.Append(passedHistory);
        }
        public void AddQuestionHistory(object passedHistory)
        {
            QuestionHistory.Append(passedHistory);
        }
        public void AddUrlHistory(object passedHistory)
        {
            UrlHistory.Append(passedHistory);
        }
    }
}
