using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VidCat_Tool.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Userprofile()
        {
            return View();
        }

        public void GetFirstName(string FirstName) // nieuw wachtwoord hashen
        {

        }
    }
}