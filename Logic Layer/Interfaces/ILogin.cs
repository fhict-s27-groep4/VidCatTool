using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Interfaces
{
    public interface ILogin
    {
        bool ValidateUser(string username, string password, IUser queryUser);

        bool ValidateAccountDisabled(IUser queryUser);
    }
}
