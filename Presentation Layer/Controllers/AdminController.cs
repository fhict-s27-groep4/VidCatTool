using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.RequestHandlers;
using Service_Layer.SessionExtension;
using Service_Layer.ViewModels;

namespace VidCat_Tool.Controllers
{
    [SessionCheck]
    [ServiceFilterAttribute(typeof(AdminCheck))]
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
            return View(userHandler.GetUserManagementViewModel());
        }


        public IActionResult DisableAccount(string userid)
        {
            userHandler.DisableUser(userid);
            return View();
        }

        // Stored Procedure maken
        public IActionResult ResetPassword(string userid)
        {
            return View();
        }
    }
}