using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class LoginViewTest
    {
        LoginViewModel login;
        public LoginViewTest()
        {
            login = new LoginViewModel();
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            login.Password = "LOL";
            login.Username = "KEK";

            Assert.Equal("LOL", login.Password);
            Assert.Equal("KEK", login.Username);
        }
        [Fact]
        public void CheckGetSetNotEqual()
        {
            login.Password = "LOLf";
            login.Username = "KEdK";

            Assert.NotEqual("LOL", login.Password);
            Assert.NotEqual("KEK", login.Username);
        }
    }
}
