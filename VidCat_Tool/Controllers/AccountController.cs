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

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountHandler _accountHandler;

        public AccountController(IAccountHandler accountHandler)
        {
            _accountHandler = accountHandler;
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
                if(_accountHandler.ValidateUser(vm.UserName, vm.Password))
                {
                    HttpContext.Session.SetString("Username", vm.UserName);
                    return View("../Home/Dashboard");
                }
            }
            TempData["FailedLoginAttempt"] = "The username or password were incorrect";
            return View();
        }   
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("../Account/Login");
        }

        public IActionResult ResetCredentials()
        {
            return View();
        }
    }
}