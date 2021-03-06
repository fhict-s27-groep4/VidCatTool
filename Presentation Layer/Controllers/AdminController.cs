﻿using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly PictureHandler pictureHandler;

        public AdminController(UserHandler userHandler, VideoHandler videoHandler, PictureHandler pictureHandler)
        {
            this.userHandler = userHandler;
            this.videoHandler = videoHandler;
            this.pictureHandler = pictureHandler;
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
                if (userHandler.CreateUser(vm))
                {
                    ViewBag.Message = "User succesfully created. You will now be redirected to User Management";
                }
                else
                {
                    ViewBag.FailMessage = "An error appeared by creating the user";
                }
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


        public IActionResult ResetPassword(string username)
        {
            userHandler.ResetPassWord(username);
            return Redirect(Url.Action("UserManagement", "Admin"));
        }

        /*____________________________________________________________*/

        [HttpGet]
        public IActionResult VideoManagement()
        {
            return View("Videomanagement", videoHandler.GetVideoManagementViewModel());
        }

        public FileResult ExportToJSON()
        {
            byte[] fileBytes = videoHandler.ExportAllVideosToJson();
            return File(fileBytes, "application/json", "JsonExport.json");
        }

        [HttpPost]
        public IActionResult UploadJSON(VideoManagementViewModel model)
        {
            bool result = videoHandler.ExpandJson(model.Post.File);
            if (result == false) { TempData["JSONUpload_Error"] = "Failed to upload JSON File."; }
            return VideoManagement();
        }


        /*____________________________________________________________*/

        [HttpGet] //Settings page where admins can set stuff, such as percentages of the algorithm.
        public IActionResult Settings()
        {
            return View(new SettingsModel()
            {
                AlgoritmSettings = videoHandler.GetAlgoritmSettings(),
                MailSettings = new MailSettings()
                {
                    Client = Service_Layer.GlobalSettings.MailSettings.Client.Host,
                    FromAddress = Service_Layer.GlobalSettings.MailSettings.NoReplyAdress.ToString()
                },
                NewUser = new MailContent()
                {
                    Content = Service_Layer.GlobalSettings.MailSettings.NewUserContent,
                    Subject = Service_Layer.GlobalSettings.MailSettings.NewUserSubject
                },
                ResetPassword = new MailContent()
                {
                    Content = Service_Layer.GlobalSettings.MailSettings.ResetContent,
                    Subject = Service_Layer.GlobalSettings.MailSettings.ResetSubject
                },
                EnableSSL = Service_Layer.GlobalSettings.MailSettings.EnableSSL,
                Port = Service_Layer.GlobalSettings.MailSettings.Port,
                NetworkCredentials = Service_Layer.GlobalSettings.MailSettings.NetworkCredentials
            });
        }

        [HttpPost]
        public IActionResult Settings(SettingsModel model)
        {
            Service_Layer.GlobalSettings.MailSettings.SetMailAddress(model.MailSettings.FromAddress);
            Service_Layer.GlobalSettings.MailSettings.SetResetContent(model.ResetPassword.Content);
            Service_Layer.GlobalSettings.MailSettings.SetResetSubject(model.ResetPassword.Subject);
            Service_Layer.GlobalSettings.MailSettings.SetUserContent(model.NewUser.Content);
            Service_Layer.GlobalSettings.MailSettings.SetUserSubject(model.NewUser.Subject);
            Service_Layer.GlobalSettings.MailSettings.SetSMTPClient(model.MailSettings.Client);
            Service_Layer.GlobalSettings.MailSettings.SetSSL(model.EnableSSL);
            Service_Layer.GlobalSettings.MailSettings.SetPort(model.Port);
            Service_Layer.GlobalSettings.MailSettings.SetNetworkCredentials(model.NetworkCredentials);
            
            return Settings();
        }
    }
}