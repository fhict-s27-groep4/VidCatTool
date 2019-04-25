using BusinessLogicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidCat_Tool.Models;

namespace VidCat_Tool.ViewModels
{
    public class AdminViewModel
    {
        public List<User> SelectedUsers { get; set; }

        public  AdminViewModel()
        {
            SelectedUsers = new List<User>();
        }

    }
}
