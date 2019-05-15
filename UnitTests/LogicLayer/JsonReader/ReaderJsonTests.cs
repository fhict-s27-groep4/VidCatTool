using Logic_Layer.JsonReader;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.LogicLayer.JsonReader
{
    public class ReaderJsonTests
    {
        private readonly ReaderJson readerJson;
        public ReaderJsonTests()
        {
            readerJson = new ReaderJson();
        }
        [Fact]
        public void JsonReaderSearchVideoURL()
        {
            Assert.Equal("https://cdn.jwplayer.com/videos/Eq8rlVfq-Fs88Rtdh.mp4", readerJson.GetVideoUrl("Eq8rlVfq"));
        }
        [Fact]
        public void JsonReaderReturnNull()
        {
            Assert.Null(readerJson.GetVideoUrl("HAHA"));
        }

        [Fact]
        public void JSonReaderTitle()
        {
            Assert.Equal("Nyan Cat Really Exists and He Lives in Russia", readerJson.GetVideoTitle("KWeGeUcF"));
        }

        [Fact]
        public void JsonReaderTitleReturnNull()
        {
            Assert.Null(readerJson.GetVideoTitle("HAHA"));
        }
    }
}
