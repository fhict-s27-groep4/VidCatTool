using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.RequestHandlers;
using Service_Layer.ViewModels;
using VidCat_Tool.Models;

namespace VidCat_Tool.Controllers
{
    [SessionCheck]
    public class HomeController : Controller
    {
        private readonly PictureHandler picturehandler ;
        public HomeController(PictureHandler picturehandler)
        {
            this.picturehandler = picturehandler;
        }
        public IActionResult Dashboard()
        {
            PictureManagementViewModel picVM = new PictureManagementViewModel();
            picVM.Get = picturehandler.GetUserIdWithPicture();
            return View(picVM);
        }
        [HttpPost]
        public void PictureUpload(PictureManagementViewModel model)
        {
            Task.Run(() => picturehandler.PictureCopy(model.Post.File));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
