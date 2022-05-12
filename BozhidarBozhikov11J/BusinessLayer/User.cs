using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int ID { get; private set; }

        [Required, MaxLength(20)]
        public string firstName { get; set; }

        [Required, MaxLength(20)]
        public string lastName { get; set; }

        [Required, Range(18, 81)]
        public int age { get; set; }

        [Required, MaxLength(20)]
        public string username { get; set; }

        [Required, MaxLength(70)]
        public string password { get; set; }

        [Required]
        public List<User> friends { get; set; }

        [Required, Range(2, 2)]
        public List<Area> areas { get; set; }

        public User(string _firstName, string _lastName, int _age, string _username, string _password, List<User> _friends, List<Area> _areas)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
            username = _username;
            password = _password;
            friends = _friends;
            areas = _areas;
        }
    }
}
