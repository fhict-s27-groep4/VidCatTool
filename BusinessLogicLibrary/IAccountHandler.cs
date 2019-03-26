using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public interface IAccountHandler
    {
        bool ValidateUser(string username, string password);
    }
}
