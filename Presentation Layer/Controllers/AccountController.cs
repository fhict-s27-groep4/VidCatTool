using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Service_Layer;
using Service_Layer.RequestHandlers;
using Service_Layer.ViewModels;
using Service_Layer.SessionExtension;
using System.IO;

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserHandler userHandler;

        public AccountController(UserHandler userHandler)
        {
            this.userHandler = userHandler;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if(userHandler.ValidateLoginAttempt(vm))
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            TempData["FailedLoginAttempt"] = "The username or password were incorrect";
            return View();
        }   
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult ResetCredentials(ResetCredentialsViewModel _rcvm)
        {
            userHandler.ResetPassWord(_rcvm.UserName);
            return View();
        }

        public IActionResult ResetCredentials()
        {
            return View();
        }
    }
}