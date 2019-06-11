using Data_Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.SessionExtension
{
    public class SessionHandler
    {
        private readonly IUserRepository userRepo;

        public ISession Session { get; private set; }

        public SessionHandler(IHttpContextAccessor httpContextAccessor, IUserRepository userRepo)
        {
            this.Session = httpContextAccessor.HttpContext.Session;
            this.userRepo = userRepo;
        }

        public void SetUsernameKey(string value)
        {
            Session.SetString("Username", value);
        }

        public void SetIDKey(string value)
        {
            Session.SetString("UserID", value);
        }

        public void SetAdminKey(string value)
        {
            Session.SetString("IsAdmin", value);
        }

        public void SetProfilePicture(string location)
        {
            Session.SetString("ProfilePicture", location);
        }

        public void ClearSession()
        {
            Session.Clear();
        }

        public bool IsUserAdmin()
        {
            ILoginUser loginUser = userRepo.GetByUUID(Session.GetUserIDKey());
            return loginUser.IsAdmin;
        }
    }
}
