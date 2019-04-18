using BusinessLogicLibrary.Models;
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
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach(var user in userRepo.GetAll())
            {
                users.Add(ConvertHandler.ConvertTo<User>(user));
            }
            return users;
        }
    }
}
