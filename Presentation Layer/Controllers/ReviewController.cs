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

        public ReviewController(VideoAssignHandler assignHandler, RatingHandler ratingHandler)
        {
            this.assignHandler = assignHandler;
            this.ratingHandler = ratingHandler;
        }

        [HttpGet]
        public IActionResult Review()
        {
            var video = assignHandler.AssignRandomVideo(HttpContext.Session.GetString("Username"));
            ViewBag.VideoIdentity = video.UrlIdentity;
            ViewBag.VideoLink = assignHandler.GetVideoLink(video.UrlIdentity);
            return View();
        }

        [HttpGet]
        public IActionResult Review()
        {//merge with above
            CategoryManager manager = new CategoryManager(_categoryRepo);
            var tierOne = manager.GetAllTierOne();
            ReviewViewModel viewModel = new ReviewViewModel();
            viewModel.ReviewGetInfo = new ReviewViewModelGet();
            viewModel.ReviewGetInfo.Categories = tierOne;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetSubCategories(int id)
        {
            //move to service layer
            CategoryManager manager = new CategoryManager(_categoryRepo);
            var subTiers = manager.GetSubTiers(new Category
            {
                UniqueID = id
            });//change to list
            return Json(subTiers);
        }

        [HttpPost]
        public IActionResult Review(ReviewViewModel postModel, bool next)
        {
            ratingHandler.AddRating(postModel);
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