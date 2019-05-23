using System;
using System.Collections.Generic;
using Xunit;
using System.Text;
using Logic_Layer.PassWordGenerator;

namespace UnitTests.LogicLayer.RandomPassword
{
    public class RandomPass
    {
        PasswordGenerator gen;
        public RandomPass()
        {
            gen = new PasswordGenerator();
        }

        [Fact]
        public void PasswordsNotTheSameAll()
        {
            string one = gen.GeneratePassword(true, true, true, true, true, 8);
            string two = gen.GeneratePassword(true, true, true, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingLower()
        {
            string one = gen.GeneratePassword(false, true, true, true, true, 8);
            string two = gen.GeneratePassword(false, true, true, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingupper()
        {
            string one = gen.GeneratePassword(true, false, true, true, true, 8);
            string two = gen.GeneratePassword(true, false, true, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingnumeric()
        {
            string one = gen.GeneratePassword(true, true, false, true, true, 8);
            string two = gen.GeneratePassword(true, true, false, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingSpecial()
        {
            string one = gen.GeneratePassword(true, true, true, false, true, 8);
            string two = gen.GeneratePassword(true, true, true, false, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameExcludingSpaces()
        {
            string one = gen.GeneratePassword(true, true, true, true, false, 8);
            string two = gen.GeneratePassword(true, true, true, true, false, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameRandom()
        {
            string one = gen.GeneratePassword(false, true, true, true, false, 8);
            string two = gen.GeneratePassword(true, true, false, true, true, 8);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsNotTheSameAllMaxLenght()
        {
            string one = gen.GeneratePassword(true, true, true, true, true, 50);
            string two = gen.GeneratePassword(true, true, true, true, true, 50);
            Assert.NotEqual(one, two);
        }
        [Fact]
        public void PasswordsToShortTestMessage()
        {
            Exception ex = Assert.Throws<System.ArgumentException>(() => gen.GeneratePassword(true, true, true, true, true, 5));
            Assert.Equal("The length of the password must be between 8 - 50 characters", ex.Message);
        }
        [Fact]
        public void PasswordsToLongTestMessage()
        {
            Exception ex = Assert.Throws<System.ArgumentException>(() => gen.GeneratePassword(true, true, true, true, true, 100));
            Assert.Equal("The length of the password must be between 8 - 50 characters", ex.Message);
        }
        [Fact]
        public void PasswordsToShort()
        {
           Assert.Throws<System.ArgumentException>(() => gen.GeneratePassword(true, true, true, true, true, 5));
        }
        [Fact]
        public void PasswordsToLong()
        {
           Assert.Throws<System.ArgumentException>(() => gen.GeneratePassword(true, true, true, true, true, 100));
        }
    }
}
