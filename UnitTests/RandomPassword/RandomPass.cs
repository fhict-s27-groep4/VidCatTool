using System;
using System.Collections.Generic;
using Xunit;
using System.Text;
using Logic_Layer;

namespace UnitTests.RandomPassword
{
    public class RandomPass
    {
        public RandomPass()
        {
                
        }

        [Fact]
        public void PasswordsNotTheSameAll()
        {
            string one = PasswordGenerator.GeneratePassword(true, true, true, true, true, 8);
            string two = PasswordGenerator.GeneratePassword(true, true, true, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingLower()
        {
            string one = PasswordGenerator.GeneratePassword(false, true, true, true, true, 8);
            string two = PasswordGenerator.GeneratePassword(false, true, true, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingupper()
        {
            string one = PasswordGenerator.GeneratePassword(true, false, true, true, true, 8);
            string two = PasswordGenerator.GeneratePassword(true, false, true, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingnumeric()
        {
            string one = PasswordGenerator.GeneratePassword(true, true, false, true, true, 8);
            string two = PasswordGenerator.GeneratePassword(true, true, false, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingSpecial()
        {
            string one = PasswordGenerator.GeneratePassword(true, true, true, false, true, 8);
            string two = PasswordGenerator.GeneratePassword(true, true, true, false, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingSpaces()
        {
            string one = PasswordGenerator.GeneratePassword(true, true, true, true, false, 8);
            string two = PasswordGenerator.GeneratePassword(true, true, true, true, false, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameRandom()
        {
            string one = PasswordGenerator.GeneratePassword(false, true, true, true, false, 8);
            string two = PasswordGenerator.GeneratePassword(true, true, false, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameAllMaxLenght()
        {
            string one = PasswordGenerator.GeneratePassword(true, true, true, true, true, 50);
            string two = PasswordGenerator.GeneratePassword(true, true, true, true, true, 50);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsToShort()
        {
            Exception ex = Assert.Throws<System.ArgumentException>(() => PasswordGenerator.GeneratePassword(true, true, true, true, true, 5));
            Assert.Equal("The length of the password must be between 8 - 50 characters", ex.Message);
        }
        [Fact]
        public void PasswordsToLong()
        {
            Exception ex = Assert.Throws<System.ArgumentException>(() => PasswordGenerator.GeneratePassword(true, true, true, true, true, 100));
            Assert.Equal("The length of the password must be between 8 - 50 characters", ex.Message);
        }
    }
}
