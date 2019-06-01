using System;
using System.Collections.Generic;
using System.Text;
using Logic_Layer.Handlers;
using Logic_Layer.Hasher;
using Model_Layer.Interface;
using Model_Layer.Models;
using Xunit;

namespace UnitTests.LogicLayer.AccountHand
{
    public class AccountHandlerTests
    {
        private readonly AccountManager account;
        public AccountHandlerTests()
        {
            account = new AccountManager(new PasswordHasher());
        }
        [Fact]
        public void ValidateUserTest()
        {
            //arrange
            User user = new User
            {
                UserID = "5",
                PassWord = "F6-BE-64-90-A0-58-83-D4-1E-D5-8A-1D-72-94-CF-9A-10-94-4A-41-D9-9A-CE-4B-A4-C3-84-F0-C0-77-DF-57",
                PassWordSalt = "vvFZoAwtYHaHVmfNnS9vXnvlsIJZKFnPcTNb4Es9XqVjftiMmoWHXl5/D9t2RLZReSlhUwTTFwDK01s67mOukw==",
                IsAdmin = false,
                IsDisabled = false
            };

            //assert
            Assert.True(account.ValidateUser("ultra_safe_P455w0rD", user));            
        }
        [Fact]
        public void ValidateUserFailTest()
        {
            //arrange
            User user = new User
            {
                UserID = "5",
                PassWord = "F6-BE-64-90-A0-58-83-D4-1E-D5-8A-1D-72-94-CF-9A-10-94-4A-41-D9-9A-CE-4B-A4-C3-84-F0-C0-",
                PassWordSalt = "vvFZoAwtYHaHVmfNnS9vXnvlsIJZKFnPcTNb4Es9XqVjftiMmoWHXl5/D9t2RLZReSlhUwTTFwDK01s67mOukw==",
                IsAdmin = false,
                IsDisabled = false
            };

            //assert
            Assert.False(account.ValidateUser("ultra_safe_P455w0rD", user));
        }
        [Fact]
        public void CreateAUser()
        {
            //arrange
            List<User> users = new List<User>();
            User user1 = new User();
            User user2 = new User();
            user1.City = "Oisterwijk";
            user1.UserID = "15";
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
            user1.IsDisabled = false;

            user2.City = "Oisterwijk";
            user2.UserID = "15";
            user2.Country = "Netherlands";
            user2.Email = "Yodonthavetoknow@gmail.com";
            user2.FirstName = "Puncan";
            user2.LastName = "Rchoenmakers";
            user2.IsAdmin = true;
            user2.PassWord = "NotActuallyAPassword";
            user2.PassWordSalt = "NotActuallyASalt";
            user2.PhoneNumber = "0651418572";
            user2.StreetAddress = "Prinses Willem Laan";
            user2.UserName = "3now";
            user2.ZipCode = "5068RE";
            user2.IsDisabled = false;

            //act
            users.Add(user1);
            users.Add(user2);

            var fulluser2 = account.CreateUser(users, "Vinnie", "DeGekkert", "DeenigeEchteVinnie@gmail.com", "0651489306", "Netherlands", "Maastricht", "Geenideestraat 5", "5061GS");

            //assert
            Assert.NotEmpty(fulluser2.UserName);
            Assert.Equal("Vinnie", fulluser2.FirstName);

        }
        [Fact]
        public void CreateUserThatAlreadyExists()
        {
            //arrange
            List<User> users = new List<User>();
            User user1 = new User();
            User user2 = new User();
            user1.City = "Oisterwijk";
            user1.UserID = "15";
            user1.Country = "Netherlands";
            user1.Email = "Youdonthavetoknow@gmail.com";
            user1.FirstName = "Duncan";
            user1.LastName = "Schoenmakers";
            user1.IsAdmin = true;
            user1.PassWord = "NotActuallyAPassword";
            user1.PassWordSalt = "NotActuallyASalt";
            user1.PhoneNumber = "0651418572";
            user1.StreetAddress = "Prinses Willem Laan";
            user1.UserName = "d.schoenmakers";
            user1.ZipCode = "5068RE";
            user1.IsDisabled = false;

            user2.City = "Oisterwijk";
            user2.UserID = "15";
            user2.Country = "Netherlands";
            user2.Email = "Yodonthavetoknow@gmail.com";
            user2.FirstName = "Puncan";
            user2.LastName = "Rchoenmakers";
            user2.IsAdmin = true;
            user2.PassWord = "NotActuallyAPassword";
            user2.PassWordSalt = "NotActuallyASalt";
            user2.PhoneNumber = "0651418572";
            user2.StreetAddress = "Prinses Willem Laan";
            user2.UserName = "3now";
            user2.ZipCode = "5068RE";
            user2.IsDisabled = false;

            //act
            users.Add(user1);
            users.Add(user2);

            var fulluser2 = account.CreateUser(users, "Duncan", "Schoenmakers", "DeenigeEchteVinnie@gmail.com", "0651489306", "Netherlands", "Maastricht", "Geenideestraat 5", "5061GS");

            //assert
            Assert.Equal("d.schoenmakers2", fulluser2.UserName);
        }        
    }
}
