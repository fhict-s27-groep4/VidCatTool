﻿using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace VidCat_Tool.Controllers
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("Username")))
            {
                var test = filterContext.HttpContext.Session.GetString("Username");
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Account" },
                                { "Action", "Login" }
                                });
            }
        }
    }
}
