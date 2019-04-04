using BusinessLogicLibrary.Hasher;
using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class AccountHandler : IAccountHandler
    {
        private readonly IUserRepository _userRepo;
        private ApplicationUser _appUser;

        public AccountHandler(IUserRepository userRepo, ApplicationUser appUser)
        {
            _userRepo = userRepo;
            _appUser = appUser;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            bool attempt = false;
            PasswordHasher hasher = new PasswordHasher();

            var users = await _userRepo.GetAll();
            var loginUser = users.Where(u => u.Username == username).FirstOrDefault();

            if(loginUser.Password == hasher.CheckPassword(password, loginUser.PasswordSalt))
            {
                attempt = true;
                _appUser = ConvertHandler.ConvertTo<ApplicationUser>(loginUser);
            }
            else
            {
                attempt = false;
            }

            return attempt;
        }
    }
}

