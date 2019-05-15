using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model_Layer.Models
{
    public class User : IUser, ILoginUser, ISearchUser, IRegisterUser
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PassWordSalt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDisabled { get; set; }
    }
}
