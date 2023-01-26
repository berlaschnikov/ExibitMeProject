using SQLite;
using ExibitMeProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace ExibitMeProject.Models
{
    //[Serializable]
    public class Organizer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Organisation { get; set; }
        public string Password { get; set; }
        [TextBlob("ExposBlobbed")]
        public List<Expo> Expos { get; set; }

        public Organizer(int id, string name, string organisation, string password)
        {
            Id = id;
            Name = name;
            Organisation = organisation;
            Password = password;
            Expos = new List<Expo>();
        }

        public Organizer(string name, string organisation, string password)
        {
            Name = name;
            Organisation = organisation;
            Password = password;
            Expos = new List<Expo>();
        }
        public Organizer()
        {
            Expos = new List<Expo>();
        }

        public void AddExpo(Expo expo)
        {
            Expos.Add(expo);
        }
    }
}
