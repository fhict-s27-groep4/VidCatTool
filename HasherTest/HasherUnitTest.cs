using System;
using Xunit;
using VidCat_Tool;


namespace HasherTest
{
    public class HasherUnitTest
    {
        private readonly VidCat_Tool.Controllers.AccountController vidcat;

        public HasherUnitTest()
        {
            vidcat = new VidCat_Tool.Controllers.AccountController();
        }

        //[Fact]
        //public void Hasher_Met_Salt_Twee_Keer_Hetzelfde()
        //{
        //    string password = "henk";
        //    vidcat.HashWithSalt(password);
        //    string first = vidcat.hashtotal;
        //    string key = vidcat.key;
        //    var result = vidcat.checkpassword(password, key);
        //    Assert.Equal(first, result);
        //}

        //[Fact]
        //public void Twee_Keer_Niet_Dezelfde_Key()
        //{
        //    string een = vidcat.GenerateRandomCryptographicKey(64);
        //    string twee = vidcat.GenerateRandomCryptographicKey(64);
        //    Assert.NotEqual(een, twee);
        //}
    }
}
