using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class VideoManagementViewModelPost
    {
        public IFormFile File { get; set; }
    }
}
