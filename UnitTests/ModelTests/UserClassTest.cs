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
            user.Firstname = "Duncan";
            user.Lastname = "Schoenmakers";
            user.IsAdmin = true;
            user.Password = "NotActuallyAPassword";
            user.PasswordSalt = "NotActuallyASalt";
            user.Phonenumber = "0651418572";
            user.Streetaddress = "Prinses Willem Laan";
            user.Username = "2now";
            user.Zipcode = "5068RE";
            user.IsDisabled = false;

            //assert
            Assert.Equal("Oisterwijk", user.City);
            Assert.Equal("Netherlands", user.Country);
            Assert.Equal("Youdonthavetoknow@gmail.com", user.Email);
            Assert.Equal("Duncan", user.Firstname);
            Assert.Equal("Schoenmakers", user.Lastname);
            Assert.Equal("15", user.UserID);
            Assert.True(user.IsAdmin);
            Assert.Equal("NotActuallyAPassword", user.Password);
            Assert.Equal("NotActuallyASalt", user.PasswordSalt);
            Assert.Equal("0651418572", user.Phonenumber);
            Assert.Equal("Prinses Willem Laan", user.Streetaddress);
            Assert.Equal("2now", user.Username);
            Assert.Equal("5068RE", user.Zipcode);
            Assert.False(user.IsDisabled);

        }
        [Fact]
        public void CheckGetSetFalseUser()
        {
            //act
            user.City = "Oisterwijk";
            user.Country = "Netherlands";
            user.Email = "Youdonthavetoknow@gmail.com";
            user.Firstname = "Duncan";
            user.Lastname = "Schoenmakers";
            user.IsAdmin = true;
            user.Password = "NotActuallyAPassword";
            user.PasswordSalt = "NotActuallyASalt";
            user.Phonenumber = "0651418572";
            user.Streetaddress = "Prinses Willem Laan";
            user.Username = "2now";
            user.Zipcode = "5068RE";
            user.IsDisabled = true;
            user.UserID = "16";


            //assert
            Assert.NotEqual("Paris", user.City);
            Assert.NotEqual("France", user.Country);
            Assert.NotEqual("SiasPLoit@gmail.com", user.Email);
            Assert.NotEqual("Jan", user.Firstname);
            Assert.NotEqual("Qu're", user.Lastname);
            Assert.NotEqual("NotActuallyAPasswords", user.Password);
            Assert.NotEqual("NotActuallyASalts", user.PasswordSalt);
            Assert.NotEqual("0651418554", user.Phonenumber);
            Assert.NotEqual("Prinses Willem Straat", user.Streetaddress);
            Assert.NotEqual("2nowa", user.Username);
            Assert.NotEqual("5068GE", user.Zipcode);
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
            rating1.IsPADDivergent = true;
            rating1.PleasureIndex = 4;
            rating1.RatingID = 5;
            rating1.UserID = "15";
            rating1.VideoIdentity = "ABCDEFG";

            //act
            Ratinglist.Add(rating1);
            user.Ratings = Ratinglist;

            //assert
            Assert.NotEmpty(user.Ratings);
        }

    }
}
