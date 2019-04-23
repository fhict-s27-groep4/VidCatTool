using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VidCat_Tool.ViewModels;
using Microsoft.AspNetCore.Http;
using Service_Layer;

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountHandler accountHandler;
        private readonly UserManager userManager;

        public AccountController(AccountHandler accountHandler, UserManager userManager)
        {
            this.accountHandler = accountHandler;
            this.userManager = userManager;
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
                if(accountHandler.ValidateUser(vm.UserName, vm.Password))
                {
                    ApplicationUser appUser = userManager.GetLoginUser(vm.UserName);
                    HttpContext.Session.SetString("Username", appUser.Username);
                    HttpContext.Session.SetString("UserID", appUser.UserID);
                    HttpContext.Session.SetString("IsAdmin", appUser.IsAdmin.ToString());

                    return View("../Home/Dashboard");
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

        public IActionResult ResetCredentials()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }
    }
}