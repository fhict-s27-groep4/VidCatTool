﻿using Logic_Layer.JsonReader;
using Model_Layer.Interface;
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
            IObjectPair<string, string> titleImage = readerJson.GetVideoTitleAndImage("KWeGeUcF");
            Assert.Equal("Nyan Cat Really Exists and He Lives in Russia", titleImage.Object1);
            Assert.Equal("https://cdn.jwplayer.com/thumbs/KWeGeUcF-720.jpg", titleImage.Object2);
        }

        [Fact]
        public void JsonReaderTitleReturnNull()
        {
            IObjectPair<string, string> titleImage = readerJson.GetVideoTitleAndImage("HaHa");
            Assert.Null(titleImage.Object1);
            Assert.Null(titleImage.Object2);
        }

        [Fact]
        public void FormatCheck()
        {
            readerJson.CheckFileFormatting(@"..\..\..\..\Logic Layer\JsonReader\VideoFeed.json");
        }
    }
}
