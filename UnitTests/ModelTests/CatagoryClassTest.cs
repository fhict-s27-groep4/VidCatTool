using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ModelTests
{
    public class CatagoryClassTest
    {
        Category catagory;
        public CatagoryClassTest()
        {
            catagory = new Category();
        }
        [Fact]
        public void CheckGetSetCategory()
        {
            //arange
            catagory.UniqueID = 1;
            catagory.ParentID = 5;
            catagory.Name = "Auto";

            //assert
            Assert.Equal(1, catagory.UniqueID);
            Assert.Equal(5, catagory.ParentID);
            Assert.Equal("Auto", catagory.Name);
        }
        [Fact]
        public void CheckGetSetNotEqualCategory()
        {
            //arange
            catagory.UniqueID = 1;
            catagory.ParentID = 5;
            catagory.Name = "Auto";

            //assert
            Assert.NotEqual(2, catagory.UniqueID);
            Assert.NotEqual(7, catagory.ParentID);
            Assert.NotEqual("Autos", catagory.Name);
        }
        [Fact]
        public void CheckRatingCategory()
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
            rating1.VideoIdentity = "ABCDEFG";

            //act
            Ratinglist.Add(rating1);
            catagory.Ratings = Ratinglist;

            //assert
            Assert.NotEmpty(catagory.Ratings);
        }
    }
}
