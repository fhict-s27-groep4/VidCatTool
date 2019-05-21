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
                if(loggedInUser.IsDisabled)
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
                if(ratingcount.Where((t) => t.Item2 == user.UserID).Select(x => x.Item1).FirstOrDefault() < 6)
                {
                    divergent = "More ratings needed";
                }
                else if(divergentRatings.Any(x => x.Item2.Contains(user.UserID)))
                {
                    divergent = Math.Round(divergentRatings.Where((t) => t.Item2 == user.UserID).Select(x => x.Item1).FirstOrDefault() / Convert.ToDouble(ratingcount.Where((t) => t.Item2 == user.UserID).Select(x => x.Item1).FirstOrDefault()) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                    divergent += "%";
                }

                usermodels.Add(new UserManagementViewModel
                {
                    User = user,
                    RatingCount = ratingcount.Where((t) => t.Item2 == user.UserID).Select(x => x.Item1).DefaultIfEmpty(0).FirstOrDefault(),
                    ProcentDivergent = divergent
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
            PasswordGenerator gen = new PasswordGenerator();
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
