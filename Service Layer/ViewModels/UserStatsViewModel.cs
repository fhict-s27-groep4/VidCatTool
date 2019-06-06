using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class UserStatsViewModel
    {
        public IUser User { get; set; }
        public Int64 ViewedCount { get; set; }
        public Int64 TotalVideos { get; set; }
        public Int64 FinishedVideos { get; set; }
        public Int64 UnFinishedVideos { get; set; }
        public decimal AverageViewedVideos { get; set; }
    }
}
