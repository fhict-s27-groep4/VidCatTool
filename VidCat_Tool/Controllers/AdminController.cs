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
            users.Add(new User()
            {
                Username = "MartinaeyNL",
                Email = "MartinBlabla@gmail.com",
                Firstname = "Martin",
                Lastname = "Peeters",
                IsAdmin = true
            });
            users.Add(new User()
            {
                Username = "Farloc",
                Email = "Twan_Rooijackers_BusinessMail@student.business.nl",
                Firstname = "Twan",
                Lastname = "Rooijackers",
                IsAdmin = false
            });
            users.Add(new User()
            {
                Username = "BlackMania_Vincent123",
                Email = "Vincent@studentplus.fontys.nl",
                Firstname = "Vincent",
                Lastname = "Muijtjens",
                IsAdmin = true
            });
            users.Add(new User()
            {
                Username = "Arometiz",
                Email = "Rico@outsourcingVanS27.nl",
                Firstname = "Rico",
                Lastname = "Muijtjens",
                IsAdmin = false
            });

            var viewModel = new AdminViewModel()
            {
                SelectedUsers = users
            };

            return View(viewModel);
        }

        public IActionResult VideoManagement()
        {
            return View();
        }

        /*____________________________________________________*/

        //When wanting to add a new user, this page opens
        public IActionResult AddUser()
        {
            return View();
        }
    }
}