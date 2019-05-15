using Logic_Layer.JsonReader;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.JsonReader
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
    }
}
