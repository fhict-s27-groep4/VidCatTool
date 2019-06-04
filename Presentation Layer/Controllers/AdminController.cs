using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
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

        /*____________________________________________________________*/

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

        /*____________________________________________________________*/

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

        /*____________________________________________________________*/
        
        [HttpGet]
        public IActionResult VideoManagement()
        {
            return View(videoHandler.GetVideoManagementViewModel());
        }
        
        public FileResult ExportToJSON()
        {
            byte[] fileBytes = videoHandler.ExportAllVideosToJson();
            return File(fileBytes, "application/json", "JsonExport");
        }

        [HttpPost]
        public IActionResult UploadJSON(IFormFile file)
        {
            videoHandler.ExpandJson(null); //Filestream must be read, NOT A TASK FOR THE FRONT END
            return View();
        }


        /*____________________________________________________________*/

        [HttpGet] //Settings page where admins can set stuff, such as percentages of the algorithm.
        public IActionResult Settings() {
            AlgoritmSettingsModel settings = videoHandler.GetAlgoritmSettings();
            return View(settings);
        }

        [HttpPost]
        public IActionResult Settings(AlgoritmSettingsModel model)
        {
            if (ModelState.IsValid)
            {
                videoHandler.SetAlgoritmSensitiveness(model);
                return VideoManagement();
            }
            return Settings();
        }
    }
}