using BusinessLogicLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidCat_Tool.Controllers
{
    public class AdminCheck : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("Username")))
            {
                var test = filterContext.HttpContext.Session.GetString("Username");
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Home" },
                                { "Action", "Dashboard" }
                                });
            }
        }
    }
}
