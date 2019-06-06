using Model_Layer.Interface;
using Model_Layer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logic_Layer.JsonReader
{
    public class ReaderJson : IReaderJson
    {
        JObject json;
        public ReaderJson()
        {
            try
            {
                json = JObject.Parse(File.ReadAllText(@"..\..\..\..\Logic Layer\JsonReader\VideoFeed.json"));
            }
            catch
            {
                json = JObject.Parse(File.ReadAllText(@"..\Logic Layer\JsonReader\VideoFeed.json"));
            }

        }

        public string GetVideoUrl(string _mediaID)
        {//returns url with best quality or null if the id doe not exist 
            string filePath = null;
            int quality = 0;
            foreach (JObject video in json["playlist"])
            {//loops for every item in the playlist
                if ((string)video["mediaid"] == _mediaID)
                {//contains the mediaID
                    foreach (JObject source in video["sources"])
                    {//checks all sources
                        string currLink = (string)source["file"];
                        if (currLink.Substring(currLink.Length - 3) == "mp4")
                        {//found a video
                            string CurrLabel = (string)source["label"];
                            try
                            {
                                if (Convert.ToInt32(CurrLabel.Substring(0, CurrLabel.Length - 1)) > quality)
                                {//found a better quality video
                                    filePath = currLink;
                                    quality = Convert.ToInt32(CurrLabel.Substring(0, CurrLabel.Length - 1));
                                }
                            }
                            catch { }
                        }
                    }
                    return filePath;
                }
            }
            return null;
        }

        public IObjectPair<string, string> GetVideoTitleAndImage(string _mediaID)
        {
            IObjectPair<string, string> titleImage = new ObjectPair<string, string>();
            foreach (JObject video in json["playlist"])
            {//loops for every item in the playlist
                if ((string)video["mediaid"] == _mediaID)
                {
                    titleImage.Object1 = (string)video["title"];
                    titleImage.Object2 = (string)video["image"];
                    return titleImage;
                }
            }
            return titleImage;
        }

        public IEnumerable<string> CheckFileFormatting(string filePath)
        {
            if (!filePath.EndsWith(".json"))
            {
                return null;
            }
            IList<string> mediaIDs = new List<string>();
            JObject newFile = JObject.Parse(File.ReadAllText(filePath));
            try
            {
                foreach (JObject video in newFile["playlist"])
                {
                    string mediaID = (string)video["mediaid"];
                    mediaIDs.Add(mediaID);
                    if (mediaID.Length != 8 ||
                        ((string)video["description"]) == null ||
                        ((int)video["pubdate"]).ToString().Length != 10 ||
                        !((string)video["image"]).EndsWith(".jpg") ||
                        (JObject)video["variations"] == null ||
                        ((string)video["feedid"]).Length != 8 ||
                        !((JArray)video["sources"]).Any(x => ((string)x["file"]).EndsWith(".mp4")) ||
                        !((JArray)video["tracks"]).All(x => (string)x["kind"] != null || (string)x["file"] != null) ||
                        ((string)video["link"]) == null ||
                        ((int)video["duration"]) < 0 ||
                        ((string)video["preview"]).Length != 8)
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return mediaIDs;
        }
    }
}