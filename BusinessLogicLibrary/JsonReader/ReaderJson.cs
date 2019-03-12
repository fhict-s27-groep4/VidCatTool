using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace BusinessLogicLibrary.JsonReader
{
    class ReaderJson
    {
        public ReaderJson()
        {//make sure you're using this nuget package Newtonsoft.Json and using Newtonsoft.Json.Linq;

        }

        private string FindVidUrl(string _mediaID, string _file)
        {//returns url with best quality or null if the id doe not exist 
            JObject json = JObject.Parse(File.ReadAllText(_file));
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
            return FindVidUrl(_mediaID, "jsonLink.json");
        }

        public string GetVideoUrl(string _mediaID, string _jsonFilePath)
        {
            return FindVidUrl(_mediaID, _jsonFilePath);
        }
    }
}
