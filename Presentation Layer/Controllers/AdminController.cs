using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.RequestHandlers;
using Service_Layer.ViewModels;

namespace VidCat_Tool.Controllers
{
    //[SessionCheck]
    public class AdminController : Controller
    {
        private readonly UserHandler userHandler;

        public AdminController(UserHandler userHandler)
        {
            this.userHandler = userHandler;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult ExportToJSON()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                userHandler.CreateUser(vm);
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserManagement()
        {
            return View();
        }
    }
}