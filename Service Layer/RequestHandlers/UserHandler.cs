using Data_Layer.Interface;
using Logic_Layer.Interfaces;
using Model_Layer.Interface;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.RequestHandlers
{
    public class UserHandler
    {
        private readonly ILogin loginHandler;
        private readonly IRegister registerHandler;
        private readonly IUserRepository userRepo;

        public UserHandler(ILogin loginHandler, IRegister registerHandler, IUserRepository userRepo)
        {
            this.loginHandler = loginHandler;
            this.registerHandler = registerHandler;
            this.userRepo = userRepo;
        }

        public bool ValidateLoginAttempt(LoginViewModel vm)
        {
            IUser loggedInUser = userRepo.GetUserByName(vm.Username);
            if(loginHandler.ValidateUser(vm.Username, vm.Password, loggedInUser))
            {
                return true;
            }
            return false;
        }

        public void CreateUser(RegisterViewModel vm)
        {
            registerHandler.CreateUser(userRepo.GetAll(), vm.Firstname, vm.Lastname, vm.Email, vm.Phonenumber, vm.Country, null, vm.Streetname, vm.Zip);
        }
    }
}
