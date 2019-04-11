using BusinessLogicLibrary.Hasher;
using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class AccountHandler
    {
        private readonly IUserRepository _userRepo;

        public AccountHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            PasswordHasher hasher = new PasswordHasher();

            var users = await _userRepo.GetAll();
            var loginUser = users.Where(u => u.Username == username).FirstOrDefault();

            if(loginUser.Password == hasher.CheckPassword(password, loginUser.PasswordSalt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

