using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class Area
    {
        [Key]
        public int ID { get; private set; }

        [Required, MaxLength(20)]
        public string name { get; set; }

        public List<User> users { get; set; }

        public Area(string _name, List<User> _users)
        {
            name = _name;
            users = _users;
        }
    }
}
