using System;
using System.Collections.Generic;
using System.Text;
using Logic_Layer.Handlers;
using Model_Layer.Interface;
using Model_Layer.Models;
using Xunit;

namespace UnitTests.LogicLayer.AccountHand
{
    public class AccountHandlerTests
    {
        private readonly AccountHandler account;
        public AccountHandlerTests()
        {
            account = new AccountHandler();
        }
        [Fact]
        public void ValidateUserTest()
        {
            User user = new User();
            user.UserID = "5";
            user.PassWord = "F6-BE-64-90-A0-58-83-D4-1E-D5-8A-1D-72-94-CF-9A-10-94-4A-41-D9-9A-CE-4B-A4-C3-84-F0-C0-77-DF-57";
            user.PassWordSalt = "vvFZoAwtYHaHVmfNnS9vXnvlsIJZKFnPcTNb4Es9XqVjftiMmoWHXl5/D9t2RLZReSlhUwTTFwDK01s67mOukw==";
            user.IsAdmin = false;
            user.IsDisabled = false;
            Assert.True(account.ValidateUser("ultra_safe_P455w0rD", user));            
        }
        [Fact]
        public void ValidateUserFailTest()
        {
            User user = new User();
            user.UserID = "5";
            user.PassWord = "F6-BE-64-90-A0-58-83-D4-1E-D5-8A-1D-72-94-CF-9A-10-94-4A-41-D9-9A-CE-4B-A4-C3-84-F0-C0-";
            user.PassWordSalt = "vvFZoAwtYHaHVmfNnS9vXnvlsIJZKFnPcTNb4Es9XqVjftiMmoWHXl5/D9t2RLZReSlhUwTTFwDK01s67mOukw==";
            user.IsAdmin = false;
            user.IsDisabled = false;
            Assert.False(account.ValidateUser("ultra_safe_P455w0rD", user));
        }
        //[Fact]
        //public void 
    }
}
