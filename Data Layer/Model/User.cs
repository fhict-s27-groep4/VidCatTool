using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Layer.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Streetaddress { get; set; }
        public string Zipcode { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
