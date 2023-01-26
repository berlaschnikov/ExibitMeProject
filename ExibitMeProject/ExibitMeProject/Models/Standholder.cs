using ExibitMeProject.Views.Visitor;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Standholder
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }
        public Expo Expo { get; set; }
        [TextBlob("LeadsBlobbed")]
        public List<Visitor> Leads { get; set; }

        public Standholder(int id, string name, string company, string password, Expo expo)
        {
            Id = id;
            Name = name;
            Company = company;
            Password = password;
            Expo = expo;
            Leads = new List<Visitor>();
        }

        public Standholder(string name, string company, string password, Expo expo)
        {
            Name = name;
            Company = company;
            Password = password;
            Expo = expo;
            Leads = new List<Visitor>();
        }
        
        public Standholder()
        {
            Leads = new List<Visitor>();
        }

        public void AddVisitor(Visitor visitor)
        {
            Leads.Add(visitor);
        }
    }
}
