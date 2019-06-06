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
        private readonly VideoManagementViewModelGet video;
        public VideoManagementViewTest()
        {
            video = new VideoManagementViewModelGet();
        }
        [Fact]
        public void ChecGetSetEqual()
        {
            IObjectPair<double, double> pls = new ObjectPair<double, double>
            {
                Object1 = 5,
                Object2 = 8
            };
            video.ArrouselAverageAndDeviation = pls;
            video.DominanceAverageAndDeviation = pls;
            video.PleaureAverageAndDeviation = pls;
            video.Thumbnail = "KEKPIC";
            List<IObjectPair<string, int>> help1 = new List<IObjectPair<string, int>>();
            IObjectPair<string, int> help = new ObjectPair<string, int>
            {
                Object1 = "LOL",
                Object2 = 5
            };
            help1.Add(help);
            IEnumerable<IObjectPair<string, int>> pls2 = help1;
            video.IABCategoryNameAndPercentage = pls2;
            video.Title = "IOBJECTPAIRSUK";
            video.WatchCount = 50;
            ISearchVideo search = new Video
            {
                Finished = true
            };
            video.Video = search;

            Assert.Equal(5, video.ArrouselAverageAndDeviation.Object1);
            Assert.Equal(8, video.ArrouselAverageAndDeviation.Object2);
            Assert.Equal(5, video.DominanceAverageAndDeviation.Object1);
            Assert.Equal(8, video.DominanceAverageAndDeviation.Object2);
            Assert.Equal(5, video.PleaureAverageAndDeviation.Object1);
            Assert.Equal(8, video.PleaureAverageAndDeviation.Object2);
            Assert.NotEmpty(video.IABCategoryNameAndPercentage);
            Assert.Equal("KEKPIC", video.Thumbnail);
            Assert.Equal("IOBJECTPAIRSUK", video.Title);
            Assert.Equal(50, video.WatchCount);
            Assert.True(video.Video.Finished);            
        }
    }
}
