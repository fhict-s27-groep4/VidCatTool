using System;
using System.Collections.Generic;
using System.Dynamic;
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
        private readonly RatingManager ratingManager;

        public ReviewController(AssignManager assignManager, UserManager userManager, RatingManager ratingManager)
        {
            this.assignManager = assignManager;
            this.userManager = userManager;
            this.ratingManager = ratingManager;
        }

        [HttpGet]
        public IActionResult Review()
        {
            ApplicationUser appUser = userManager.GetLoginUser(HttpContext.Session.GetString("Username"));
            var video = assignManager.AssignRandomVideo(appUser.Username);
            ViewBag.VideoIdentity = video.UrlIdentity;
            ViewBag.VideoLink = video.VideoURL;
            return View();
        }

        [HttpPost]
        public IActionResult Review(ReviewViewModelPost postModel, bool next)
        {
            ApplicationUser appUser = userManager.GetLoginUser(HttpContext.Session.GetString("Username"));
            Video vid = assignManager.GetVideo(postModel.VideoIdentity);
            ratingManager.AddRating(appUser.UserID, vid.VideoID, 1, postModel.Pleasure, postModel.Arrousal, postModel.Dominance);
            if (next == true)
            {
                return RedirectToAction("Review");
            }
            else
            {
                return RedirectToAction("Dashboard", "Home");
            }
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}