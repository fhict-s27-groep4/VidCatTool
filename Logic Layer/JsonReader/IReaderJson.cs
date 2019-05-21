using Model_Layer.Interface;

namespace Logic_Layer.JsonReader
{
    public interface IReaderJson
    {
        IObjectPair<string, string> GetVideoTitleAndImage(string _mediaID);
        string GetVideoUrl(string _mediaID);
    }
}