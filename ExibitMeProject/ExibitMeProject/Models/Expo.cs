using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Expo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        [TextBlob("OrganizerBlobbed")]
        public Organizer Organizer { get; set; }
        [TextBlob("StandholdersBlobbed")]
        public List<Standholder> Standholders { get; set; }

        public Expo(int id, string name, string location, string date, Organizer organizer)
        {
            Id = id;
            Name = name;
            Location = location;
            Date = date;
            Organizer = organizer;
            Standholders = new List<Standholder>();
        }

        public Expo(string name, string location, string date, Organizer organizer)
        {
            Name = name;
            Location = location;
            Date = date;
            Organizer = organizer;
            Standholders = new List<Standholder>();
        }

        public Expo()
        {
            Standholders = new List<Standholder>();
        }

        public void AddStandholder(Standholder standholder)
        {
            Standholders.Add(standholder);
        }
        public void AddOrganizer(Organizer organizer)
        {
            Organizer = organizer;
        }
    }
}
