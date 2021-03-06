using System;
using Xunit;
using System.Security.Authentication;
using Logic_Layer.Hasher;

namespace UnitTests.LogicLayer.Hasher
{
    public class HasherUnitTest
    {
        private readonly PasswordHasher PassHash;

        public HasherUnitTest()
        {
            PassHash = new PasswordHasher();
        }

        [Fact]
        public void Hasher_Met_Salt_Twee_Keer_Hetzelfde()
        {
            string password = "henk";
            string first = PassHash.HashWithSalt(password);
            string key = PassHash.Key;
            var result = PassHash.CheckPassword(password, key);
            Assert.Equal(first, result);
        }

        [Fact]
        public void Twee_Keer_Niet_Dezelfde_Key()
        {
            string een = PassHash.GenerateRandomCryptographicKey(64);
            string twee = PassHash.GenerateRandomCryptographicKey(64);
            Assert.NotEqual(een, twee);
        }
        [Fact]
        public void GetSetKeyHasherException()
        {
            Exception ex = Assert.Throws<System.ArgumentException>(() => PassHash.Key = "ABCDEFGHIJ");

            Assert.Equal("Key value is empty.", ex.Message);
        }
    }
}
