using SQLite;
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
        public List<Visitor> Leads { get; set; }
    }
}
