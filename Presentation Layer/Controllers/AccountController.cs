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

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserHandler userHandler;
        private readonly SessionHandler sessionHandler;

        public AccountController(UserHandler userHandler, SessionHandler sessionHandler)
        {
            this.userHandler = userHandler;
            this.sessionHandler = sessionHandler;
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
                    sessionHandler.SetUsernameKey(vm.Username);

                    return View("../Home/Dashboard");
                }
            }
            TempData["FailedLoginAttempt"] = "The username or password were incorrect";
            return View();
        }   

        [HttpPost]
        public FileResult ExportToJSON()
        {

            byte[] fileBytes = System.IO.File.ReadAllBytes();
            return File(fileBytes, "json", "JsonExport");
        }
        
        public IActionResult Logout()
        {
            sessionHandler.ClearSession();
            return View();
        }

        public IActionResult ResetCredentials()
        {
            return View();
        }
    }
}