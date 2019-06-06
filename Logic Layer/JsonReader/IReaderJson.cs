using Model_Layer.Interface;
using System.Collections.Generic;

namespace Logic_Layer.JsonReader
{
    public interface IReaderJson
    {
        IObjectPair<string, string> GetVideoTitleAndImage(string _mediaID);
        string GetVideoUrl(string _mediaID);
        IEnumerable<string> CheckFileFormatting(string filePath);
    }
}