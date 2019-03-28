using System;
using Xunit;
using VidCat_Tool.Controllers;
using System.Security.Authentication;
using NuGet.Frameworks;
using BusinessLogicLibrary.Hasher;

namespace UnitTests
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
            PassHash.HashWithSalt(password);
            string first = PassHash.GetHashTotal();
            string key = PassHash.GetKey();
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
    }
}