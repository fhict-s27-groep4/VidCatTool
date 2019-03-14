using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VidCat_Tool.ViewModels;

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginHandler _loginHandler;

        public AccountController(ILoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
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
                if(_loginHandler.ValidateUser(vm.UserName, vm.Password))
                {
                    return View("Dashboard");
                }
            }
            return View();
        }        
    }
}