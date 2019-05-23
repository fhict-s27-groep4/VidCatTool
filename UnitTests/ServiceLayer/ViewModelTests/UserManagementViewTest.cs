using Model_Layer.Interface;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class User : ISearchUser
    {
        public string UserID { get; set; }

        public bool IsDisabled { get; set; }

        public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string StreetAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ZipCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class UserManagementViewTest
    {
        UserManagementViewModel user;
        public UserManagementViewTest()
        {
            user = new UserManagementViewModel();
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            user.ProcentDivergent = "5";
            user.RatingCount = 50;
            User users = new User();
            users.UserID = "15";
            users.IsDisabled = false;
            user.User = users;

            Assert.Equal("5", user.ProcentDivergent);
            Assert.Equal(50, user.RatingCount);
            Assert.False(user.User.IsDisabled);
            Assert.Equal("15", user.User.UserID);            
        }
        [Fact]
        public void CheckGetSetNotEqual()
        {
            user.ProcentDivergent = "45";
            user.RatingCount = 504;
            User users = new User();
            users.UserID = "145";
            user.User = users;

            Assert.NotEqual("5", user.ProcentDivergent);
            Assert.NotEqual(50, user.RatingCount);
            Assert.NotEqual("15", user.User.UserID);
        }
    }
}
