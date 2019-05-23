using Data_Layer.Interface;
using Logic_Layer.Interfaces;
using Model_Layer.Interface;
using Service_Layer.SessionExtension;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Logic_Layer;
using Logic_Layer.SMTPMessageSender;
using Logic_Layer.Hasher;
using Logic_Layer.PassWordGenerator;
using Model_Layer.Models;

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
            this.loginHandler = loginHandler ?? throw new NullReferenceException();
            this.registerHandler = registerHandler ?? throw new NullReferenceException();
            this.userRepo = userRepo ?? throw new NullReferenceException();
            this.sessionHandler = sessionHandler ?? throw new NullReferenceException();
        }

        public bool ValidateLoginAttempt(LoginViewModel vm)
        {
            ILoginUser loggedInUser = userRepo.GetUserByName(vm.Username) as ILoginUser;
            if (loginHandler.ValidateUser(vm.Password, loggedInUser))
            {
                if (loggedInUser.IsDisabled)
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

        public void CreateUser(RegisterViewModel vm)
        {
            IRegisterUser generatedUser = registerHandler.CreateUser(userRepo.GetAll(), vm.Firstname, vm.Lastname, vm.Email, vm.Phonenumber, vm.Country, vm.City, vm.Streetname, vm.Zip);
            userRepo.AddUser(generatedUser);
        }

        public IReadOnlyCollection<UserManagementViewModel> GetUserManagementViewModel()
        {
            List<UserManagementViewModel> usermodels = new List<UserManagementViewModel>();
            IEnumerable<IObjectPair<int, string>> ratingcount = userRepo.GetRatingCountFromAllUsers();
            IEnumerable<IObjectPair<int, string>> divergentIABRatings = userRepo.GetDivergentIABRatingsFromAllUser();
            IEnumerable<IObjectPair<int, string>> divergentPADRatings = userRepo.GetDivergentPADRatingsFromAllUser();
            IObjectPair<int, string> defaultPair = new ObjectPair<int, string>() { Object1 = -1 };
            foreach (ISearchUser user in userRepo.GetAll())
            {
                usermodels.Add(new UserManagementViewModel
                {
                    User = user,
                    RatingCount = ratingcount.Where((t) => t.Object2 == user.UserID).Select(x => x.Object1).DefaultIfEmpty(0).FirstOrDefault(),
                    ProcentIABDivergent = divergentIABRatings.Where(x => x.Object2 == user.UserID).DefaultIfEmpty(defaultPair).First().Object1,
                    ProcentPADDivergent = divergentPADRatings.Where(x => x.Object2 == user.UserID).DefaultIfEmpty(defaultPair).First().Object1
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

        public void ResetPassWord(string _userName)
        {
            PasswordHasher hasher = new PasswordHasher();
            IPasswordGenerator gen = new PasswordGenerator();
            ILoginUser loggedInUser = userRepo.GetUserByName(_userName) as ILoginUser;
            string generatedPassword = gen.GeneratePassword(true, true, true, true, false, 12);
            userRepo.UpdatePassword(loggedInUser.UserID, hasher.HashWithSalt(generatedPassword), hasher.Key);
            EMailSender eMailer = new EMailSender();
            IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
            mail.MakeMail("New Password For VidCatTool", String.Format("Dear Sir/Madam, \n\n The password of this account has been reset.\n Please login with the following password: {0} \n\n Kind regards, \n The staff of JWPlayer", generatedPassword), loggedInUser.Email);
            eMailer.Send(mail);
        }
    }
}
