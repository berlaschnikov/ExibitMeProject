using SQLite;
using System;
using System.Collections.Generic;
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
    }
}
