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
using VidCat_Tool.ViewModels;
using Microsoft.AspNetCore.Http;

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            return View();
        }   
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("../Account/Login");
        }

        public IActionResult ResetCredentials()
        {
            return View();
        }
    }
}