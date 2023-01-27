using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Url
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlBody { get; set; }

        public Url(int id, string name, string urlBody)
        {
            Id = id;
            Name = name;
            UrlBody = urlBody;
        }

        public Url(string name,string urlBody)
        {
            UrlBody = urlBody;
        }
        public Url()
        {

        }
    }
}
