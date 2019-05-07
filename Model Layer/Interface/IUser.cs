using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface IUser
    {
        string Username { get; set; }
        string Email { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Phonenumber { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Streetaddress { get; set; }
        string Zipcode { get; set; }
    }
}
