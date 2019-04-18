using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VidCat_Tool.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Streetaddress { get; set; }
        public string Zipcode { get; set; }
        public bool IsAdmin { get; set; }
        //public ICollection<Rating> Ratings { get; set; }
    }
}
