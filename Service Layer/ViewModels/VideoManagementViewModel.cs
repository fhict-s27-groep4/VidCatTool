using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class VideoManagementViewModel
    {
        public ISearchVideo Video { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public int WatchCount { get; set; }
        public IObjectPair<double, double> PleaureAverageAndDeviation { get; set; }
        public IObjectPair<double, double> ArrouselAverageAndDeviation { get; set; }
        public IObjectPair<double, double> DominanceAverageAndDeviation { get; set; }
        public IEnumerable<IObjectPair<string, int>> IABCategoryNameAndPercentage { get; set; }
    }
}
