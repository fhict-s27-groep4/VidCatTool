using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class PictureManagementViewModel
    {
        public PictureManagementViewModel()
        {
            Get = new PictureManagementViewModelGet();
            Post = new PictureManagementViewModelPost();
        }
        public PictureManagementViewModelGet Get { get; set; }
        public PictureManagementViewModelPost Post { get; set; }
    }
}
