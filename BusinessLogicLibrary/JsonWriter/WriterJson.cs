using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLogicLibrary.JsonWriter
{
    class WriterJson
    {
        private double Deviation(IEnumerable<int> _scores)
        {
            double average = _scores.Average();
            IList<double> squareRoots = new List<double>();
            foreach (int score in _scores)
            {
                squareRoots.Add(Math.Pow((average + score) % score, 2));
            }
            return Math.Pow(squareRoots.Average(), 0.5);
        }
        private JObject PADScore(IEnumerable<int> _padScores)
        {
            JObject padScore = new JObject();
            padScore.Add("average", _padScores.Average());
            padScore.Add("deviation", Deviation(_padScores));
            return padScore;
        }
        private JObject PADScores(IEnumerable<IRating> _ratings)
        {
            JObject padscores = new JObject();
            padscores.Add("pleasure", PADScore(_ratings.Select(x => x.Pleasure)));
            padscores.Add("arousel", PADScore(_ratings.Select(x => x.Arrousel)));
            padscores.Add("dominance", PADScore(_ratings.Select(x => x.Dominance)));
            return padscores;
        }

        private JArray Categories(IEnumerable<IRating> _ratings)
        {
            JArray categories = new JArray();
            return categories;
        }
        private JObject Video(IEnumerable<IRating> _ratings)
        {
            JObject video = new JObject();
            video.Add("id", _ratings.First().mediaID);
            video.Add("pad", PADScores(_ratings));
            video.Add("iad", Categories(_ratings));
            return video;
        }

        public void Write(IEnumerable<IRating> _ratings)
        {
            JObject jObject = new JObject();
            JArray videos = new JArray();
            string filename = "../../JsonExport" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".json";
            StreamWriter stream = new StreamWriter(File.Create(filename));
            JsonSerializer serializer = new JsonSerializer();

            IEnumerable<string> mediaIDs = _ratings.Select(x => x.mediaID).Distinct();
            foreach (string s in mediaIDs)
            {
                videos.Add(Video(_ratings.Where(x => x.mediaID == s)));
            }
            jObject.Add("videos", videos);
            serializer.Serialize(stream, jObject);
            stream.Close();
        }
    }

    public interface IRating
    {
        string mediaID { get; }
        int UniqueCategory1 { get; }
        int UniqueCategory2 { get; }
        bool IABIsDivergent { get; set; }
        int Pleasure { get; }
        int Arrousel { get; }
        int Dominance { get; }
        bool PADIsDivergent { get; set; }
    }
}
