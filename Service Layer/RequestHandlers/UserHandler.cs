using Data_Layer.Interface;
using Logic_Layer.Interfaces;
using Model_Layer.Interface;
using Service_Layer.SessionExtension;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Service_Layer.RequestHandlers
{
    public class UserHandler
    {
        private readonly ILogin loginHandler;
        private readonly IRegister registerHandler;
        private readonly IUserRepository userRepo;
        private readonly SessionHandler sessionHandler;

        public UserHandler(ILogin loginHandler, IRegister registerHandler, IUserRepository userRepo, SessionHandler sessionHandler)
        {
            this.loginHandler = loginHandler;
            this.registerHandler = registerHandler;
            this.userRepo = userRepo;
            this.sessionHandler = sessionHandler;
        }

        public bool ValidateLoginAttempt(LoginViewModel vm)
        {
            ILoginUser loggedInUser = userRepo.GetUserByName(vm.Username) as ILoginUser;
            if(loginHandler.ValidateUser(vm.Password, loggedInUser))
            {
                if(loginHandler.ValidateAccountDisabled(loggedInUser))
                {
                    return false;
                }
                sessionHandler.SetIDKey(loggedInUser.UserID);
                sessionHandler.SetUsernameKey(loggedInUser.UserName);
                sessionHandler.SetAdminKey(loggedInUser.IsAdmin.ToString());
                return true;
            }
            return false;
        }

        // City vergeten in de UI te zetten
        public void CreateUser(RegisterViewModel vm)
        {
            IRegisterUser generatedUser = registerHandler.CreateUser(userRepo.GetAll(), vm.Firstname, vm.Lastname, vm.Email, vm.Phonenumber, vm.Country, null, vm.Streetname, vm.Zip);
            userRepo.AddUser(generatedUser);
        }

        public IReadOnlyCollection<UserManagementViewModel> GetUserManagementViewModel()
        {
            List<UserManagementViewModel> usermodels = new List<UserManagementViewModel>();
            var ratingcount = userRepo.GetRatingCountFromAllUsers();
            var divergentRatings = userRepo.GetDivergentRatingsFromAllUser();
            foreach (ISearchUser user in userRepo.GetAll())
            {
                string divergent = "More ratings needed";
                if (ratingcount.Any(x => x.Item2.Contains(user.UserID)))
                {

                }

                usermodels.Add(new UserManagementViewModel
                {
                    User = user,
                    RatingCount = ratingcount.Where((t) => t.Item2 == user.UserID).Select(x => x.Item1).DefaultIfEmpty(0).FirstOrDefault(),
                });
            }

            return usermodels;
        }

        public void DisableUser(string userid)
        {
            userRepo.DisableUser(userid);
        }
        public void EnableUser(string userid)
        {
            userRepo.EnableUser(userid);
        }

    }
}
