using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VidCat_Tool.Controllers
{
    // [SessionCheck]
    public class AdminController : Controller
    {
        public IActionResult UserManagement()
        {
            return View();
        }
    }
}