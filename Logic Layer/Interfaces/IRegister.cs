using Model_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Interfaces
{
    public interface IRegister
    {
        IRegisterUser CreateUser(IEnumerable<IUser> allUsers, string firstname, string lastname, string email, string phonenumber = null, string country = null, string city = null, string streetaddress = null, string zipcode = null);
    }
}
