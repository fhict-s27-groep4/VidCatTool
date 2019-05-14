using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Logic_Layer.JsonReader
{
    public class ReaderJson
    {
        JObject json;
        public ReaderJson()
        {
            //make sure you're using this nuget package Newtonsoft.Json and using Newtonsoft.Json.Linq;
            try
            {
                json = JObject.Parse(File.ReadAllText(@"..\..\..\..\Logic Layer\JsonReader\VideoFeed.json"));
            }
            catch
            {
                json = JObject.Parse(File.ReadAllText(@"..\Logic Layer\JsonReader\VideoFeed.json"));
            }

        }

        private string FindVidUrl(string _mediaID)
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

        public string GetVideoUrl(string _mediaID)
        {
            return FindVidUrl(_mediaID);
        }
    }
}