using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class ReviewViewModel
    {
        public ReviewViewModel()
        {
            Get = new ReviewViewModelGet();
            Post = new ReviewViewModelPost();
        }
        public ReviewViewModelGet Get { get; set; }

        public ReviewViewModelPost Post { get; set; }
    }
}
