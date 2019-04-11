using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VidCat_Tool.ViewModels;

namespace VidCat_Tool.Controllers
{
    [SessionCheck]
    public class ReviewController : Controller
    {
        private readonly AssignManager assignManager;
        private readonly UserManager userManager;

        public ReviewController(AssignManager assignManager, UserManager userManager)
        {
            this.assignManager = assignManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Review()
        {
            ApplicationUser appUser = userManager.GetLoginUser(HttpContext.Session.GetString("Username"));
            ReviewViewModel vm = new ReviewViewModel();
            vm.ReviewGetInfo = new ReviewViewModelGet();
            var video = assignManager.AssignRandomVideo(appUser.Username);
            vm.ReviewGetInfo.VideoIdentity = video.UrlIdentity;
            vm.ReviewGetInfo.Videolink = video.VideoURL;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Review(ReviewViewModelPost vm)
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}