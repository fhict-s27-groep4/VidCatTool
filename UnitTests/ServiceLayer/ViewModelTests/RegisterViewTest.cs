using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class RegisterViewTest
    {
        RegisterViewModel review;
        public RegisterViewTest()
        {
            review = new RegisterViewModel();
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            review.Country = "Netherlands";
            review.Email = "Youdonthavetoknow@gmail.com";
            review.Firstname = "Duncan";
            review.Lastname = "Schoenmakers";
            review.Phonenumber = "0651418572";
            review.Housenumber = "5";
            review.Streetname = "PrinsesBeatrix";
            review.Zip = "5061AG";
            review.City = "Oisterwijk";

            Assert.Equal("Netherlands", review.Country);
            Assert.Equal("Youdonthavetoknow@gmail.com", review.Email);
            Assert.Equal("Duncan", review.Firstname);
            Assert.Equal("Schoenmakers", review.Lastname);
            Assert.Equal("0651418572", review.Phonenumber);
            Assert.Equal("5", review.Housenumber);
            Assert.Equal("PrinsesBeatrix", review.Streetname);
            Assert.Equal("5061AG", review.Zip);
            Assert.Equal("Oisterwijk", review.City);
        }
        [Fact]
        public void CheckGetSetNotEqual()
        {
            review.Country = "Netherslands";
            review.Email = "Youdonthsavetoknow@gmail.com";
            review.Firstname = "Duncasn";
            review.Lastname = "Schoesnmakers";
            review.Phonenumber = "065s1418572";
            review.Housenumber = "5s";
            review.Streetname = "PrisnsesBeatrix";
            review.Zip = "5061AGs";
            review.City = "Oisterswijk";

            Assert.NotEqual("Netherlands", review.Country);
            Assert.NotEqual("Youdonthavetoknow@gmail.com", review.Email);
            Assert.NotEqual("Duncan", review.Firstname);
            Assert.NotEqual("Schoenmakers", review.Lastname);
            Assert.NotEqual("0651418572", review.Phonenumber);
            Assert.NotEqual("5", review.Housenumber);
            Assert.NotEqual("PrinsesBeatrix", review.Streetname);
            Assert.NotEqual("5061AG", review.Zip);
            Assert.NotEqual("Oisterwijk", review.City);
        }
    }
}
