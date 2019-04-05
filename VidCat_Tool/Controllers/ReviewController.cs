using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using Microsoft.AspNetCore.Mvc;
using VidCat_Tool.ViewModels;

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
            ReviewViewModel vm = new ReviewViewModel();
            vm.ReviewGetInfo = new ReviewViewModelGet();
            var video = assignManager.AssignRandomVideo();
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