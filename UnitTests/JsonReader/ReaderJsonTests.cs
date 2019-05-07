using Logic_Layer.JsonReader;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.JsonReader
{
    public class ReaderJsonTests
    {
        [Fact]
        public void JsonReaderTest()
        {
            ReaderJson readerJson = new ReaderJson();

            Assert.Equal("https://cdn.jwplayer.com/videos/Eq8rlVfq-Fs88Rtdh.mp4", readerJson.GetVideoUrl("Eq8rlVfq"));
        }
    }
}
