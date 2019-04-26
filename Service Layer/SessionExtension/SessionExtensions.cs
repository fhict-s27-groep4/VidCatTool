using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.SessionExtension
{
    public static class SessionExtensions
    {
        public static string GetUsernameKey(this ISession session)
        {
            return session.GetString("Username");
        }

        public static string GetUserIDKey(this ISession session)
        {
            return session.GetString("UserID");
        }

        public static bool IsUserAdmin(this ISession session)
        {
            return Convert.ToBoolean(session.GetString("IsAdmin"));
        }
    }
}
