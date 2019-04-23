using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using Microsoft.AspNetCore.Mvc;
using VidCat_Tool.Models;
using VidCat_Tool.ViewModels;

namespace VidCat_Tool.Controllers
{
    //[SessionCheck]
    public class AdminController : Controller
    {
        private readonly UserManager userManager;

        public AdminController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        /*___________________________________________________________*/

        //When opening the overview of all users
        public IActionResult UserManagement()
        {
            List<User> users = new List<User>();
            //foreach (var user in userManager.GetAllUsers()) {
            //    users.Add(new User() {
            //        UserID = user.UserID,
            //        Username = user.Username,
            //        Email = user.Email,
            //        Firstname = user.Firstname,
            //        Lastname = user.Lastname,
            //        Phonenumber = user.Phonenumber,
            //        Country = user.Country,
            //        City = user.City,
            //        Streetaddress = user.Streetaddress,
            //        Zipcode = user.Zipcode,
            //        IsAdmin = user.IsAdmin
            //    });
            //}

            var viewModel = new AdminViewModel()
            {
                SelectedUsers = users
            };

            return View(viewModel);
        }

        /*____________________________________________________*/

        //When wanting to add a new user, this page opens
        public IActionResult AddUser()
        {
            return View();
        }
    }
}