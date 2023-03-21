using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Boolean Status { get; set; } 
        public DateTime DateCreation { get; set; }
        public User(string name, string userName, string lastName, string address, string email)
        {
            Name = name;
            UserName = userName;
            LastName = lastName;
            Address = address;
            Email = email;
        }
    }
}
