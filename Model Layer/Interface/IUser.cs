using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface IUser
    {
        string UserName { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string StreetAddress { get; set; }
        string ZipCode { get; set; }
    }
}
