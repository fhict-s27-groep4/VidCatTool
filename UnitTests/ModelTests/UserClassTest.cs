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

            //assert
            Assert.Equal("Oisterwijk", user.City);
            Assert.Equal("Netherlands", user.Country);
            Assert.Equal("Youdonthavetoknow@gmail.com", user.Email);
            Assert.Equal("Duncan", user.Firstname);
            Assert.Equal("Schoenmakers", user.Lastname);
            Assert.True(user.IsAdmin);
            Assert.Equal("NotActuallyAPassword", user.Password);
            Assert.Equal("NotActuallyASalt", user.PasswordSalt);
            Assert.Equal("0651418572", user.Phonenumber);
            Assert.Equal("Prinses Willem Laan", user.Streetaddress);
            Assert.Equal("2now", user.Username);
            Assert.Equal("5068RE", user.Zipcode);

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

        }

    }
}
