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
        private readonly IAccountHandler _accountHandler;
        private readonly IServiceProvider appUserService;

        public AccountController(IAccountHandler accountHandler, IServiceProvider appUserService)
        {
            _accountHandler = accountHandler;
            this.appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if(await _accountHandler.ValidateUser(vm.UserName, vm.Password))
                {
                    var appUser = (ApplicationUser)appUserService.GetRequiredService(typeof(ApplicationUser)); // Is null
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
            var appUser = (ApplicationUser)appUserService.GetService(typeof(ApplicationUser));
            HttpContext.Session.Clear();
            appUser.Reset();

            return View();
        }

        public IActionResult ResetCredentials()
        {
            return View();
        }
    }
}