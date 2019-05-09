using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ModelTests
{
    public class RatingClassTest
    {
        private Rating rating;
        public RatingClassTest()
        {
            rating = new Rating();
        }

        [Fact]
        public void CheckGetSetRating()
        {
            rating.RatingID = 20;
            rating.UserID = "90";
            rating.VideoIdentity = "ABCDEFG";
            rating.CategoryID = 15;
            rating.IsIABDivergent = true;
            rating.IsPADDivergent = true;
            rating.PleasureIndex = 4;
            rating.ArrousalIndex = 3;
            rating.DominanceIndex = 2;

            Assert.Equal(20, rating.RatingID);
            Assert.Equal("90", rating.UserID);
            Assert.Equal("ABCDEFG", rating.VideoIdentity);
            Assert.Equal(15, rating.CategoryID);
            Assert.Equal(4, rating.PleasureIndex);
            Assert.Equal(3, rating.ArrousalIndex);
            Assert.Equal(2, rating.DominanceIndex);
            Assert.True(rating.IsIABDivergent);
            Assert.True(rating.IsPADDivergent);


        }

        [Fact]
        public void CheckGetSetNotEqualRating()
        {
            rating.RatingID = 20;
            rating.UserID = "90";
            rating.VideoIdentity = "ABCDEFG";
            rating.CategoryID = 15;
            rating.IsIABDivergent = true;
            rating.IsPADDivergent = true;
            rating.PleasureIndex = 4;
            rating.ArrousalIndex = 3;
            rating.DominanceIndex = 2;

            Assert.NotEqual(24, rating.RatingID);
            Assert.NotEqual("93", rating.UserID);
            Assert.NotEqual("ABCDEFN", rating.VideoIdentity);
            Assert.NotEqual(18, rating.CategoryID);
            Assert.NotEqual(5, rating.PleasureIndex);
            Assert.NotEqual(4, rating.ArrousalIndex);
            Assert.NotEqual(3, rating.DominanceIndex);
            Assert.True(rating.IsIABDivergent);
            Assert.True(rating.IsPADDivergent);
        }
        
        [Fact]
        public void CheckGetSetNotEmptyRating()
        {

        }
    }
}
