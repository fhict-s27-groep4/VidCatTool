using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public class UserManager
    {
        private readonly IUserRepository userRepo;

        public UserManager(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public ApplicationUser GetLoginUser(string username)
        {
            ApplicationUser appUser = ConvertHandler.ConvertTo<ApplicationUser>(userRepo.GetUserByName(username));
            return appUser;
        }
    }
}
