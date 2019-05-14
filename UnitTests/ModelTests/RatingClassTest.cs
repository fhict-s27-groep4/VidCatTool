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
            rating.IsPADDivergentt = true;
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
            Assert.True(rating.IsPADDivergentt);


        }

        [Fact]
        public void CheckGetSetNotEqualRating()
        {
            rating.RatingID = 20;
            rating.UserID = "90";
            rating.VideoIdentity = "ABCDEFG";
            rating.CategoryID = 15;
            rating.IsIABDivergent = true;
            rating.IsPADDivergentt = true;
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
            Assert.True(rating.IsPADDivergentt);
        }
        
        [Fact]
        public void CheckUserRating()
        {
            //arrange
            User user1 = new User();
            user1.City = "Oisterwijk";
            user1.Country = "Netherlands";
            user1.Email = "Youdonthavetoknow@gmail.com";
            user1.FirstName = "Duncan";
            user1.LastName = "Schoenmakers";
            user1.IsAdmin = true;
            user1.PassWord = "NotActuallyAPassword";
            user1.PassWordSalt = "NotActuallyASalt";
            user1.PhoneNumber = "0651418572";
            user1.StreetAddress = "Prinses Willem Laan";
            user1.UserName = "2now";
            user1.ZipCode = "5068RE";
            user1.IsDisabled = true;
            user1.UserID = "16";

            //assert
            //Assert.NotEqual("Paris", user2.City);
            //Assert.NotEqual("France", user2.Country);
            //Assert.NotEqual("SiasPLoit@gmail.com", user2.Email);
            //Assert.NotEqual("Jan", user2.FirstName);
            //Assert.NotEqual("Qu're", user2.LastName);
            //Assert.NotEqual("NotActuallyAPasswords", user2.PassWord);
            //Assert.NotEqual("NotActuallyASalts", user2.PassWordSalt);
            //Assert.NotEqual("0651418554", user2.PhoneNumber);
            //Assert.NotEqual("Prinses Willem Straat", user2.StreetAddress);
            //Assert.NotEqual("2nowa", user2.UserName);
            //Assert.NotEqual("5068GE", user2.ZipCode);
            //Assert.NotEqual("15", user2.UserID);
            //Assert.True(user2.IsDisabled);
            throw new NotImplementedException();
        }
        [Fact]
        public void CheckvideoRating()
        {
            //arrange
            Video vid1 = new Video();
            vid1.UrlIdentity = "Tester123";
            vid1.Finished = true;


            //assert
            throw new NotImplementedException();
        }
        [Fact]
        public void CheckCategoryRating()
        {
            Category cat1 = new Category();
            cat1.ParentID = 5;
            cat1.Name = "Honda";
            cat1.UniqueID = 10;

            throw new NotImplementedException();
        }
    }
}
