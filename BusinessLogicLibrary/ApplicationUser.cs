using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace BusinessLogicLibrary
{
    public class ApplicationUser
    {
        public string UserID { get; set; }
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
        public bool? IsAdmin { get; set; }

        public void Reset()
        {
            UserID = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            PasswordSalt = string.Empty;
            Firstname = string.Empty;
            Lastname = string.Empty;
            Phonenumber = string.Empty;
            Country = string.Empty;
            City = string.Empty;
            Streetaddress = string.Empty;
            Zipcode = string.Empty;
            IsAdmin = null;

        }
    }
}
