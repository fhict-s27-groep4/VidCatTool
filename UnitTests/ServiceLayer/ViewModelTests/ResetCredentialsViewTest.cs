using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class ResetCredentialsViewTest
    {
        ResetCredentialsViewModel reset;
        public ResetCredentialsViewTest()
        {
            reset = new ResetCredentialsViewModel();
        }
        [Fact]
        public void CheckGetSetEqual()
        {
            reset.UserName = "KEK";

            Assert.Equal("KEK", reset.UserName);
        }
        [Fact]
        public void CheckGetSetNotEqual()
        {
            reset.UserName = "KE2K";

            Assert.NotEqual("KEK", reset.UserName);
        }
    }
}
