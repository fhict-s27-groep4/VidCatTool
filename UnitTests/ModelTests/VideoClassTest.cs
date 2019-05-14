using BusinessLogicLibrary;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.SmallTests
{
    public class VideoClassTest
    {
        Video vid;
        public VideoClassTest()
        {
            vid = new Video();
        }

        [Fact]
        public void CheckGetSetVideo()
        {
            //arrange
            vid.UrlIdentity = "Tester123";
            vid.Finished = true;

            //assert
            Assert.Equal("Tester123", vid.UrlIdentity);
            Assert.True(vid.Finished);
        }

        [Fact]
        public void CheckGetSetFalseVideo()
        {
            vid.UrlIdentity = "Tester123";
            vid.Finished = false;

            Assert.NotEqual("Tester124", vid.UrlIdentity);
            Assert.False(vid.Finished);
        }
        [Fact]
        public void CheckGetSetRatingsFromVideo()
        {
            //arrange
            List<Rating> Ratinglist = new List<Rating>();
            Rating rating1 = new Rating();
            rating1.ArrousalIndex = 1;
            rating1.CategoryID = 4;
            rating1.DominanceIndex = 4;
            rating1.IsIABDivergent = false;
            rating1.IsPADDivergentt = true;
            rating1.PleasureIndex = 4;
            rating1.RatingID = 5;
            rating1.UserID = "15";

            //act
            Ratinglist.Add(rating1);

            //assert
            throw new NotImplementedException();

        }
    }
}
