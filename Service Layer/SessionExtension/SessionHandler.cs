using Data_Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.SessionExtension
{
    public class SessionHandler
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ISession Session { get => httpContextAccessor.HttpContext.Session; }

        public SessionHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
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

        public void ClearSession()
        {
            Session.Clear();
        }
    }
}
