using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.RequestHandlers;
using Service_Layer.ViewModels;

namespace VidCat_Tool.Controllers
{
    [SessionCheck]
    public class ReviewController : Controller
    {
        private readonly VideoAssignHandler assignHandler;
        private readonly RatingHandler ratingHandler;
        private readonly CategoryHandler categoryHandler;

        public ReviewController(VideoAssignHandler assignHandler, RatingHandler ratingHandler, CategoryHandler categoryHandler)
        {
            this.assignHandler = assignHandler;
            this.ratingHandler = ratingHandler;
            this.categoryHandler = categoryHandler;
        }

        [HttpGet]
        public IActionResult Review()
        {
            var video = assignHandler.AssignRandomVideo(HttpContext.Session.GetString("Username"));
            ViewBag.VideoIdentity = video.UrlIdentity;
            ViewBag.VideoLink = assignHandler.GetVideoLink(video.UrlIdentity);
            return View(categoryHandler.GetTier1s());
        }

        //[HttpGet]
        //public IActionResult Review()
        //{//merge with above
        //    CategoryManager manager = new CategoryManager(_categoryRepo);
        //    var tierOne = manager.GetAllTierOne();
        //    ReviewViewModelPost viewModel = new ReviewViewModelPost();
        //    viewModel.ReviewGetInfo = new ReviewViewModelPost();
        //    viewModel.ReviewGetInfo.Categories = tierOne;
        //    return View(viewModel);
        //}

        [HttpGet]
        public IActionResult GetSubCategories(int id)
        {
            return Json(categoryHandler.GetSubTiers(id));
        }

        [HttpPost]
        public IActionResult Review(ReviewViewModel viewModel, bool next)
        {
            ratingHandler.AddRating(viewModel.Post);
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