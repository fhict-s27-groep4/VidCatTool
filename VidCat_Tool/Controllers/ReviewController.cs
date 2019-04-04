using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using Microsoft.AspNetCore.Mvc;

namespace VidCat_Tool.Controllers
{
    [SessionCheck]
    public class ReviewController : Controller
    {
        private readonly IAssignManager assignManager;

        public ReviewController(IAssignManager assignManager)
        {
            this.assignManager = assignManager;
        }

        [HttpGet]
        public IActionResult Review()
        {
            
            return View();
        }
    }
}