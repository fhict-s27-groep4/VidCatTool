using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public interface IAccountHandler
    {
        Task<bool> ValidateUser(string username, string password);

        ApplicationUser ReturnValidatedUser();
    }
}
