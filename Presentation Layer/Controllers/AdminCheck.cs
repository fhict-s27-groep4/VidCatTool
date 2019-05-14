﻿using BusinessLogicLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Service_Layer.SessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidCat_Tool.Controllers
{
    public class AdminCheck : ActionFilterAttribute
    {
        private SessionHandler sessionHandler;

        public AdminCheck(SessionHandler sessionHandler)
        {
            this.sessionHandler = sessionHandler;
        }

        // TO DO:
        // - Attribute checken
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(sessionHandler.IsUserAdmin())
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Home" },
                                { "Action", "Dashboard" }
                                });
            }
        }
    }
}
