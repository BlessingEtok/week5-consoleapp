using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Models
{
    public class User
    {
      

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string GitHub { get; set; }
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }


    }
}
