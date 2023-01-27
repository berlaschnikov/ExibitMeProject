using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExibitMeProject.Models
{
    public class Info
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string InfoBody { get; set; }

        public Info(int id, string name, string infoBody)
        {
            Id = id;
            Name = name;
            InfoBody = infoBody;
        }

        public Info(string name, string infoBody)
        {
            Name = name;
            InfoBody = infoBody;
        }

        public Info()
        {

        }
    }
}
