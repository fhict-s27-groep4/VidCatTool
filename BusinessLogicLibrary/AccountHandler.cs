using BusinessLogicLibrary.Hasher;
using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLibrary
{
    public class AccountHandler : IAccountHandler
    {
        private readonly IUserRepository _userRepo;

        public AccountHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool ValidateUser(string username, string password)
        {
            bool attempt = false;
            PasswordHasher hasher = new PasswordHasher();

            var users = _userRepo.GetAllUsers();
            var loginUser = users.Where(u => u.Username.ToLower() == username.ToLower()).FirstOrDefault();

            if(loginUser.Password == hasher.CheckPassword(password, loginUser.PasswordSalt))
            {
                attempt = true;
            }
            else
            {
                attempt = false;
            }

            return attempt;
        }
    }
}

