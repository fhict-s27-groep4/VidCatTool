using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class AddUserViewTest
    {
        AddUserViewModel user;
        public AddUserViewTest()
        {
            user = new AddUserViewModel();
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            user.Country = "Netherlands";
            user.Email = "Youdonthavetoknow@gmail.com";
            user.Firstname = "Duncan";
            user.Lastname = "Schoenmakers";
            user.Phonenumber = "0651418572";
            user.Housenumber = "5";
            user.Streetname = "PrinsesBeatrix";
            user.Zip = "5061AG";

            Assert.Equal("Netherlands", user.Country);
            Assert.Equal("Youdonthavetoknow@gmail.com", user.Email);
            Assert.Equal("Duncan", user.Firstname);
            Assert.Equal("Schoenmakers", user.Lastname);
            Assert.Equal("0651418572", user.Phonenumber);
            Assert.Equal("5", user.Housenumber);
            Assert.Equal("PrinsesBeatrix", user.Streetname);
            Assert.Equal("5061AG", user.Zip);
        }
        [Fact]
        public void CheckGetSetNotEqual()
        {
            user.Country = "Netherlands";
            user.Email = "Youdonthavetoknow@gmail.com";
            user.Firstname = "Duncan";
            user.Lastname = "Schoenmakers";
            user.Phonenumber = "0651418572";
            user.Housenumber = "5";
            user.Streetname = "PrinsesBeatrix";
            user.Zip = "5061AG";

            Assert.NotEqual("Netherlandss", user.Country);
            Assert.NotEqual("Youdonthavetoknow@gmail.cofm", user.Email);
            Assert.NotEqual("Dunscan", user.Firstname);
            Assert.NotEqual("Schoenfmakers", user.Lastname);
            Assert.NotEqual("065141s8572", user.Phonenumber);
            Assert.NotEqual("5f", user.Housenumber);
            Assert.NotEqual("PrsnsesBeatrix", user.Streetname);
            Assert.NotEqual("506f1AG", user.Zip);
        }
    }
}
