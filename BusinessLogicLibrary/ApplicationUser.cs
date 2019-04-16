using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace BusinessLogicLibrary
{
    public class ApplicationUser
    {
        public string UserID { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }
        public string Email { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Phonenumber { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Streetaddress { get; private set; }
        public string Zipcode { get; private set; }
        public bool IsAdmin { get; private set; }
        
    }
}
