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
            return Math.Round(Math.Pow(squareRoots.Average(), 0.5), 1, MidpointRounding.AwayFromZero);
        }
        private JObject PADScore(IEnumerable<int> _padScores)
        {
            JObject padScore = new JObject();
            padScore.Add("average", Math.Round(_padScores.Average(), 1, MidpointRounding.AwayFromZero));
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

        private JObject Tier2Category(IEnumerable<IRating> _ratings, double _percentage)
        {
            JObject tier2 = new JObject();
            tier2.Add("category_id", _ratings.First().UniqueCategory2);
            tier2.Add("percentage", (int)Math.Round(_percentage, MidpointRounding.AwayFromZero));
            return tier2;
        }

        private JObject Tier1Category(IEnumerable<IRating> _ratings, double _percentage)
        {
            JObject tier1 = new JObject();
            JArray tier2s = new JArray();
            tier1.Add("category_id", _ratings.First().UniqueCategory1);
            tier1.Add("percentage", (int)Math.Round(_percentage, MidpointRounding.AwayFromZero));
            foreach (int category in _ratings.Select(x => x.UniqueCategory2).Distinct().OrderBy(x => x))
            {
                tier2s.Add(Tier2Category(_ratings.Where(x => x.UniqueCategory2 == category), ((double)_ratings.Where(x => x.UniqueCategory2 == category).Count() / _ratings.Count() * 100)));
            }
            tier1.Add("tier2", tier2s);
            return tier1;
        }

        private JArray Categories(IEnumerable<IRating> _ratings)
        {
            JArray categories = new JArray();
            foreach (int category in _ratings.Select(x => x.UniqueCategory1).Distinct().OrderBy(x => x))
            {
                categories.Add(Tier1Category(_ratings.Where(x => x.UniqueCategory1 == category), ((double)_ratings.Where(x => x.UniqueCategory1 == category).Count() / _ratings.Count()) * 100));
            }
            return categories;
        }
        private JObject Video(IEnumerable<IRating> _ratings)
        {
            JObject video = new JObject();
            video.Add("id", _ratings.First().MediaID);
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
            foreach (string s in _ratings.Select(x => x.MediaID).Distinct().OrderBy(x => x))
            {
                videos.Add(Video(_ratings.Where(x => x.MediaID == s)));
            }
            jObject.Add("videos", videos);
            stream.Write(JsonConvert.SerializeObject(jObject, Formatting.Indented));
            stream.Close();
        }
    }


    public interface IRating
    {
        string MediaID { get; }
        int UniqueCategory1 { get; }
        int UniqueCategory2 { get; }
        int Pleasure { get; }
        int Arrousel { get; }
        int Dominance { get; }
    }
}
