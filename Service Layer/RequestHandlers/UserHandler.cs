﻿using Data_Layer.Interface;
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
using Data_Layer.Repository;
using System.Net.Mail;

namespace Service_Layer.RequestHandlers
{
    public class UserHandler
    {
        private readonly ILogin loginHandler;
        private readonly IRegister registerHandler;
        private readonly IUserRepository userRepo;
        private readonly IUserStatsRepository userStatsRepository;
        private readonly PictureHandler pictureHandler;
        private readonly SessionHandler sessionHandler;

        public UserHandler(PictureHandler pictureHandler, IUserStatsRepository userStatsRepository, ILogin loginHandler, IRegister registerHandler, IUserRepository userRepo, SessionHandler sessionHandler)
        {
            this.userStatsRepository = userStatsRepository ?? throw new NullReferenceException();
            this.loginHandler = loginHandler ?? throw new NullReferenceException();
            this.registerHandler = registerHandler ?? throw new NullReferenceException();
            this.userRepo = userRepo ?? throw new NullReferenceException();
            this.sessionHandler = sessionHandler ?? throw new NullReferenceException();
            this.pictureHandler = pictureHandler ?? throw new NullReferenceException();
        }

        public bool ValidateLoginAttempt(LoginViewModel vm)
        {
            ILoginUser loggedInUser = userRepo.GetUserByName(vm.Username) as ILoginUser;
            if (loggedInUser != null)
            {
                if (loginHandler.ValidateUser(vm.Password, loggedInUser))
                {
                    if (loggedInUser.IsDisabled)
                    {
                        return false;
                    }
                    sessionHandler.SetIDKey(loggedInUser.UserID);
                    sessionHandler.SetUsernameKey(loggedInUser.UserName);
                    sessionHandler.SetAdminKey(loggedInUser.IsAdmin.ToString());
                    sessionHandler.SetProfilePicture(pictureHandler.GetPictureWithUserID(loggedInUser.UserID));
                    return true;
                }
                return false;
            }
            else return false;
        }

        public bool CreateUser(RegisterViewModel vm)
        {
            IObjectPair<IRegisterUser, string> generatedUserPassPair = registerHandler.CreateUser(userRepo.GetAll(), vm.Firstname, vm.Lastname, vm.Email, vm.IsAdmin, vm.Phonenumber, vm.Country, vm.City, vm.Streetname, vm.Zip);
            try
            {
                userRepo.AddUser(generatedUserPassPair.Object1);
                ILoginUser user = userRepo.GetUserByName(generatedUserPassPair.Object1.UserName);
                if (vm.ProfilePicture != null)
                {
                    pictureHandler.PictureCopy(vm.ProfilePicture, user.UserID);
                }
                EMailSender eMailer = new EMailSender(GlobalSettings.MailSettings.Client);
                IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
                mail.MakeMail(GlobalSettings.MailSettings.NewUserSubject, String.Format(GlobalSettings.MailSettings.NewUserContent, user.UserName, generatedUserPassPair.Object2), user.Email);
                eMailer.Send(mail, GlobalSettings.MailSettings.NoReplyAdress, GlobalSettings.MailSettings.NetworkCredentials, GlobalSettings.MailSettings.EnableSSL, GlobalSettings.MailSettings.Port);
            }
            catch
            {
                return false;
                //throw new ArgumentException("Something went wrong with the registration. Check Inner Exception for specific information: /n" + excepton.InnerException.Message);
            }
            return true;
        }

        public IReadOnlyCollection<UserManagementViewModel> GetUserManagementViewModel()
        {
            List<UserManagementViewModel> usermodels = new List<UserManagementViewModel>();
            IEnumerable<IObjectPair<long, string>> ratingcount = userRepo.GetRatingCountFromAllUsers();
            IEnumerable<IObjectPair<long, string>> divergentIABRatings = userRepo.GetDivergentIABRatingsFromAllUser();
            IEnumerable<IObjectPair<long, string>> divergentPADRatings = userRepo.GetDivergentPADRatingsFromAllUser();
            IObjectPair<long, string> defaultPair = new ObjectPair<long, string>() { Object1 = 0 };
            foreach (ISearchUser user in userRepo.GetAll())
            {
                UserManagementViewModel userVM = new UserManagementViewModel();
                userVM.User = user;
                userVM.RatingCount = ratingcount.Where((t) => t.Object2 == user.UserID).Select(x => x.Object1).DefaultIfEmpty(0).FirstOrDefault();
                try
                {
                    userVM.ProcentIABDivergent = Convert.ToInt32(divergentIABRatings.Where(x => x.Object2 == user.UserID).DefaultIfEmpty(defaultPair).First().Object1 / (double)userVM.RatingCount * (double)100);
                    userVM.ProcentPADDivergent = Convert.ToInt32(divergentPADRatings.Where(x => x.Object2 == user.UserID).DefaultIfEmpty(defaultPair).First().Object1 / (double)userVM.RatingCount * (double)100);
                }
                catch
                {
                    userVM.ProcentIABDivergent = -1;
                    userVM.ProcentPADDivergent = -1;
                }
                userVM.PicturePath = pictureHandler.GetPictureWithUserID(user.UserID);
                usermodels.Add(userVM);
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
            EMailSender eMailer = new EMailSender(GlobalSettings.MailSettings.Client);
            try
            {
                IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
                mail.MakeMail(GlobalSettings.MailSettings.ResetSubject, String.Format(GlobalSettings.MailSettings.ResetContent, generatedPassword), loggedInUser.Email);
                eMailer.Send(mail, GlobalSettings.MailSettings.NoReplyAdress, GlobalSettings.MailSettings.NetworkCredentials, GlobalSettings.MailSettings.EnableSSL, GlobalSettings.MailSettings.Port);
            }
            catch { }
        }

        public UserStatsViewModel GetUserStats()
        {
            UserStats stats = userStatsRepository.GetUserStats(sessionHandler.Session.GetUserIDKey());
            return new UserStatsViewModel()
            {
                User = userRepo.GetByUUID(sessionHandler.Session.GetUserIDKey()),
                ViewedCount = stats.ViewCount,
                AverageViewedVideos = stats.AverageViewedVideos,
                FinishedVideos = stats.FinishedVideos,
                TotalVideos = stats.TotalVideos,
                UnFinishedVideos = stats.TotalVideos - stats.FinishedVideos
            };
        }
    }
}
