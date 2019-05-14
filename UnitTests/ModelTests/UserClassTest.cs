using BusinessLogicLibrary;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.SmallTests
{
    public class UserClassTest
    {
        User user;
        public UserClassTest()
        {
            user = new User();
        }
        [Fact]
        public void CheckGetSetUser()
        {
            //act
            user.City = "Oisterwijk";
            user.UserID = "15";
            user.Country = "Netherlands";
            user.Email = "Youdonthavetoknow@gmail.com";
            user.FirstName = "Duncan";
            user.LastName = "Schoenmakers";
            user.IsAdmin = true;
            user.PassWord = "NotActuallyAPassword";
            user.PassWordSalt = "NotActuallyASalt";
            user.PhoneNumber = "0651418572";
            user.StreetAddress = "Prinses Willem Laan";
            user.UserName = "2now";
            user.ZipCode = "5068RE";
            user.IsDisabled = false;

            //assert
            Assert.Equal("Oisterwijk", user.City);
            Assert.Equal("Netherlands", user.Country);
            Assert.Equal("Youdonthavetoknow@gmail.com", user.Email);
            Assert.Equal("Duncan", user.FirstName);
            Assert.Equal("Schoenmakers", user.LastName);
            Assert.Equal("15", user.UserID);
            Assert.True(user.IsAdmin);
            Assert.Equal("NotActuallyAPassword", user.PassWord);
            Assert.Equal("NotActuallyASalt", user.PassWordSalt);
            Assert.Equal("0651418572", user.PhoneNumber);
            Assert.Equal("Prinses Willem Laan", user.StreetAddress);
            Assert.Equal("2now", user.UserName);
            Assert.Equal("5068RE", user.ZipCode);
            Assert.False(user.IsDisabled);

        }
        [Fact]
        public void CheckGetSetFalseUser()
        {
            //act
            user.City = "Oisterwijk";
            user.Country = "Netherlands";
            user.Email = "Youdonthavetoknow@gmail.com";
            user.FirstName = "Duncan";
            user.LastName = "Schoenmakers";
            user.IsAdmin = true;
            user.PassWord = "NotActuallyAPassword";
            user.PassWordSalt = "NotActuallyASalt";
            user.PhoneNumber = "0651418572";
            user.StreetAddress = "Prinses Willem Laan";
            user.UserName = "2now";
            user.ZipCode = "5068RE";
            user.IsDisabled = true;
            user.UserID = "16";


            //assert
            Assert.NotEqual("Paris", user.City);
            Assert.NotEqual("France", user.Country);
            Assert.NotEqual("SiasPLoit@gmail.com", user.Email);
            Assert.NotEqual("Jan", user.FirstName);
            Assert.NotEqual("Qu're", user.LastName);
            Assert.NotEqual("NotActuallyAPasswords", user.PassWord);
            Assert.NotEqual("NotActuallyASalts", user.PassWordSalt);
            Assert.NotEqual("0651418554", user.PhoneNumber);
            Assert.NotEqual("Prinses Willem Straat", user.StreetAddress);
            Assert.NotEqual("2nowa", user.UserName);
            Assert.NotEqual("5068GE", user.ZipCode);
            Assert.NotEqual("15", user.UserID);
            Assert.True(user.IsDisabled);

        }
        [Fact]
        public void CheckUserRatings()
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

            //assert
            throw new NotImplementedException();
        }

    }
}
