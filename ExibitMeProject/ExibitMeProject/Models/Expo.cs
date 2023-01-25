using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Expo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public List<Standholder> Standholders { get; set; }
        public Organizer Organizer { get; set; }
    }
}
