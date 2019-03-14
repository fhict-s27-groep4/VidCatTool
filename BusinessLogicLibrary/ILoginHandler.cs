using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public interface ILoginHandler
    {
        bool ValidateUser(string username, string password);
    }
}
