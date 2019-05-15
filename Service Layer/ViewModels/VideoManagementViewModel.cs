using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class VideoManagementViewModel
    {
        public ISearchVideo Video { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }


        // Deze moet uiteindelijk weg 
        public IReadOnlyCollection<ISearchVideo> Videos { get; set; }
    }
}
