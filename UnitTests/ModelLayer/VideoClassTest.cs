using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ModelLayer
{
    public class VideoClassTest
    {
        private readonly Video vid;
        public VideoClassTest()
        {
            vid = new Video();
        }

        [Fact]
        public void CheckGetSetVideo()
        {
            //arrange
            vid.UrlIdentity = "Tester123";
            vid.Finished = true;

            //assert
            Assert.Equal("Tester123", vid.UrlIdentity);
            Assert.True(vid.Finished);
        }

        [Fact]
        public void CheckGetSetFalseVideo()
        {
            vid.UrlIdentity = "Tester123";
            vid.Finished = false;

            Assert.NotEqual("Tester124", vid.UrlIdentity);
            Assert.False(vid.Finished);
        }
    }
}
