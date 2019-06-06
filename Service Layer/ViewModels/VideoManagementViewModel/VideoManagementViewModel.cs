using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class VideoManagementViewModel
    {
        public IEnumerable<VideoManagementViewModelGet> Get { get; set; }
        public VideoManagementViewModelPost Post { get; set; }
    }
}
