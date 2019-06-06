using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.RequestHandlers;
using Service_Layer.ViewModels;
using VidCat_Tool.Models;

namespace VidCat_Tool.Controllers
{
    [SessionCheck]
    public class HomeController : Controller
    {
        UserHandler userHandler;

        public HomeController(UserHandler userHandler)
        {
            this.userHandler = userHandler;
        }

        public IActionResult Dashboard()
        {
            return View(userHandler.GetUserStats());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
