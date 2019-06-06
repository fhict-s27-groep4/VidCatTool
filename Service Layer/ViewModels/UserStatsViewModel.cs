using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class UserStatsViewModel
    {
        public IUser User { get; set; }
        public ulong ViewedCount { get; set; }
        public ulong TotalVideos { get; set; }
        public ulong FinishedVideos { get; set; }
        public ulong UnFinishedVideos { get; set; }
        public double AverageViewedVideos { get; set; }
    }
}
