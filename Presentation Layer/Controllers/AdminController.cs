using System.IO;
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
        private readonly VideoHandler videoHandler;

        public AdminController(UserHandler userHandler, VideoHandler videoHandler)
        {
            this.userHandler = userHandler;
            this.videoHandler = videoHandler;
        }

        public IActionResult AddUser()
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
            return Redirect(Url.Action("UserManagement", "Admin"));
        }

        public IActionResult EnableAccount(string userid)
        {
            userHandler.EnableUser(userid);
            return Redirect(Url.Action("UserManagement", "Admin"));
        }

        // Stored Procedure maken
        public IActionResult ResetPassword(string userid)
        {
            return View();
        }

        [HttpGet]
        public IActionResult VideoManagement()
        {
            return View(videoHandler.GetVideoManagementViewModel());
        }
        
        public FileResult ExportToJSON()
        {
            string file = videoHandler.ExportAllVideosToJson();
            byte[] fileBytes = System.IO.File.ReadAllBytes(Path.GetFullPath(file));
            return File(fileBytes, "application/json", "JsonExport");
        }
    }
}