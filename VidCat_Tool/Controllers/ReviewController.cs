using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidCat_Tool.ViewModels;

namespace VidCat_Tool.Controllers
{
    // [SessionCheck]
    public class ReviewController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Review()
        {
            // Hier moet de code komen om een random video te sturen naar de pagina voor een video te revieuwen.
            return View();
        }

        [HttpPost]
        public IActionResult Review(ReviewViewModelPost vm)
        {
            return View();
        }
    }
}