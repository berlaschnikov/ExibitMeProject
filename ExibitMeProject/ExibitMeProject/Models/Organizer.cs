using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Organizer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Organisation { get; set; }
    }
}
