using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public  class UserDTOView
    {

        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;

        public UserDTOView(string name, string userName, string lastName, string address, string email)
        {
            Name = name;
            UserName = userName;
            LastName = lastName;
            Address = address;
            Email = email;
        }

        public UserDTOView(string name)
        {
            Name = name;
        }
    }
}
