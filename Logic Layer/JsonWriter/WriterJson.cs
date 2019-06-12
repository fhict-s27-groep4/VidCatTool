using Logic_Layer.CategoryReverser;
using Logic_Layer.Maths;
using Model_Layer.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.JsonWriter
{
    public class WriterJson : IWriterJson
    {
        ICategoryManager categroyReverser;
        ICalculator calculator;
        public WriterJson(ICategoryManager _categroyReverser, ICalculator calculator)
        {
            categroyReverser = _categroyReverser;
            this.calculator = calculator;
        }
        private async Task<JObject> PADScore(IEnumerable<int> _padScores)
        {
            JObject padScore = new JObject();
            Task<double> deviation = Task.Run(() => calculator.Deviation(_padScores));
            padScore.Add("average", Math.Round(_padScores.Average(), 1, MidpointRounding.AwayFromZero));
            await deviation;
            padScore.Add("deviation", deviation.Result);
            return padScore;
        }
        private async Task<JObject> PADScores(IEnumerable<IDuncan> _ratings)
        {
            JObject padscores = new JObject();
            Task<JObject>[] padScoreTasks = new Task<JObject>[3];
            padScoreTasks[0] = Task.Run(() => PADScore(_ratings.Select(x => x.PleasureIndex)));
            padScoreTasks[1] = Task.Run(() => PADScore(_ratings.Select(x => x.ArrousalIndex)));
            padScoreTasks[2] = Task.Run(() => PADScore(_ratings.Select(x => x.DominanceIndex)));
            await Task.WhenAll(padScoreTasks);
            padscores.Add("pleasure", padScoreTasks[0].Result);
            padscores.Add("arousel", padScoreTasks[1].Result);
            padscores.Add("dominance", padScoreTasks[2].Result);
            return padscores;
        }

        private Task<JObject> Tier2Category(IEnumerable<IDuncan> _ratings, double _percentage)
        {
            return Task.Run(() =>
            {
                JObject tier2 = new JObject();
                tier2.Add("category_id", categroyReverser.GetParentTiers(_ratings.First().CategoryID).Object2);
                tier2.Add("percentage", (int)Math.Round(_percentage, MidpointRounding.AwayFromZero));
                return tier2;
            });
        }

        private async Task<JObject> Tier1Category(IEnumerable<IDuncan> _ratings, double _percentage)
        {
            JObject tier1 = new JObject();
            Task<JObject>[] tier2Tasks = new Task<JObject>[_ratings.Select(x => categroyReverser.GetParentTiers(x.CategoryID).Object2).Distinct().Count()];
            JArray tier2s = new JArray();
            int index = 0;
            foreach (int category in _ratings.Select(x => categroyReverser.GetParentTiers(x.CategoryID).Object2).Distinct())
            {
                tier2Tasks[index] = Task.Run(() => Tier2Category(_ratings.Where(x => categroyReverser.GetParentTiers(x.CategoryID).Object2 == category), _percentage: ((double)_ratings.Where(x => categroyReverser.GetParentTiers(x.CategoryID).Object2 == category).Count() / _ratings.Count() * 100)));
                index++;
            }
            tier1.Add("category_id", categroyReverser.GetParentTiers(_ratings.First().CategoryID).Object1);
            tier1.Add("percentage", (int)Math.Round(_percentage, MidpointRounding.AwayFromZero));
            await Task.WhenAll(tier2Tasks);
            foreach (JObject category in tier2Tasks.Select(x => x.Result))
            {
                tier2s.Add(category);
            }
            tier1.Add("tier2", tier2s);
            return tier1;
        }

        private async Task<JArray> Categories(IEnumerable<IDuncan> _ratings)
        {
            Task<JObject>[] categoryTasks = new Task<JObject>[_ratings.Select(x => categroyReverser.GetParentTiers(x.CategoryID).Object1).Distinct().Count()];
            JArray categories = new JArray();
            int index = 0;
            foreach (int category in _ratings.Select(x => categroyReverser.GetParentTiers(x.CategoryID).Object1).Distinct().OrderBy(x => x))
            {
                categoryTasks[index] = Task.Run(() => Tier1Category(_ratings.Where(x => categroyReverser.GetParentTiers(x.CategoryID).Object1 == category), ((double)_ratings.Where(x => categroyReverser.GetParentTiers(x.CategoryID).Object1 == category).Count() / _ratings.Count()) * 100));
                index++;
            }
            await Task.WhenAll(categoryTasks);
            foreach (JObject category in categoryTasks.Select(x => x.Result))
            {
                categories.Add(category);
            }
            return categories;
        }
        private async Task<JObject> Video(IEnumerable<IDuncan> _ratings)
        {
            JObject video = new JObject();
            Task<JArray> categories = Task.Run(() => Categories(_ratings));
            Task<JObject> padScores = Task.Run(() => PADScores(_ratings));
            video.Add("id", _ratings.First().VideoIdentity);
            await padScores;
            video.Add("pad", padScores.Result);
            await categories;
            video.Add("iad", categories.Result);
            return video;
        }

        public async Task<string> Write(IEnumerable<IDuncan> _ratings)
        {
            Task<JObject>[] taskArray = new Task<JObject>[_ratings.Select(x => x.VideoIdentity).Distinct().Count()];
            JObject jObject = new JObject();
            JArray videos = new JArray();
            int index = 0;
            foreach (string s in _ratings.Select(x => x.VideoIdentity).Distinct())
            {
                taskArray[index] = Task.Run(() => Video(_ratings.Where(x => x.VideoIdentity == s)));
                index++;
            }
            string filename = "JsonExport" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".json";
            StreamWriter stream = new StreamWriter(File.Create(filename));
            await Task.WhenAll(taskArray);
            foreach (JObject video in taskArray.Select(x => x.Result))
            {
                videos.Add(video);
            }
            jObject.Add("videos", videos);
            stream.Write(JsonConvert.SerializeObject(jObject, Formatting.Indented));
            stream.Close();
            return filename;
        }

        public void ExtendJson(string filePath)
        {
            JObject feed = JObject.Parse(File.ReadAllText(@"..\Logic Layer\JsonReader\VideoFeed.json"));
            JObject extend = JObject.Parse(File.ReadAllText(filePath));
            foreach (JObject video in (JArray)extend["playlist"])
            {
                ((JArray)feed["playlist"]).Add(video);
            }
            StreamWriter stream = new StreamWriter(@"..\Logic Layer\JsonReader\VideoFeed.json");
            stream.Write(JsonConvert.SerializeObject(feed, Formatting.Indented));
            stream.Close();
        }
    }
}