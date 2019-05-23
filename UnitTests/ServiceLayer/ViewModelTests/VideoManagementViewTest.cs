using Model_Layer.Interface;
using Model_Layer.Models;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class VideoManagementViewTest
    {
        VideoManagementViewModel video;
        public VideoManagementViewTest()
        {
            video = new VideoManagementViewModel();
        }
        [Fact]
        public void ChecGetSetEqual()
        {
            IObjectPair<double, double> pls = new ObjectPair<double, double>();
            pls.Object1 = 5;
            pls.Object2 = 8;
            video.ArrouselAverageAndDeviation = pls;
            video.DominanceAverageAndDeviation = pls;
            video.PleaureAverageAndDeviation = pls;
            video.Thumbnail = "KEKPIC";
            List<IObjectPair<string, int>> help1 = new List<IObjectPair<string, int>>();
            IObjectPair<string, int> help = new ObjectPair<string, int>();
            help.Object1 = "LOL";
            help.Object2 = 5;
            help1.Add(help);
            IEnumerable<IObjectPair<string, int>> pls2 = help1;
            List<ObjectPair<string, int>> god = new List<ObjectPair<string, int>>();
            god = pls2;
            video.IABCategoryNameAndPercentage = pls2;
            video.Title = "IOBJECTPAIRSUK";
            video.WatchCount = 50;
            ISearchVideo search = new Video();
            search.Finished = true;
            video.Video = search;

            Assert.Equal(5, video.ArrouselAverageAndDeviation.Object1);
            Assert.Equal(8, video.ArrouselAverageAndDeviation.Object2);
            Assert.Equal(5, video.DominanceAverageAndDeviation.Object1);
            Assert.Equal(8, video.DominanceAverageAndDeviation.Object2);
            Assert.Equal(5, video.PleaureAverageAndDeviation.Object1);
            Assert.Equal(8, video.PleaureAverageAndDeviation.Object2);
            Assert.Equal("LOL", video.
            Assert.Equal("KEKPIC", video.Thumbnail);
            Assert.Equal("IOBJECTPAIRSUK", video.Title);
            Assert.Equal(50, video.WatchCount);
            Assert.True(video.Video.Finished);            
        }
    }
}
