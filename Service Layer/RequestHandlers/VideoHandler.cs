using Data_Layer.Interface;
using Logic_Layer.AlgoritmRatings;
using Logic_Layer.CategoryReverser;
using Logic_Layer.JsonReader;
using Logic_Layer.JsonWriter;
using Logic_Layer.Maths;
using Microsoft.AspNetCore.Http;
using Model_Layer.Interface;
using Model_Layer.Models;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.RequestHandlers
{
    public class VideoHandler
    {
        private readonly IVideoRepository videoRepo;
        private readonly IRatingRepository ratingRepo;
        private readonly IWriterJson writer;
        private readonly IReaderJson jsonReader;
        private readonly ICalculator calculator;
        private readonly ICategoryManager categoryManager;
        private readonly IRatingSettings settings;

        public VideoHandler(IVideoRepository videoRepo, IRatingRepository _ratingRepo, IReaderJson readerJson, IWriterJson writerJson, ICalculator calculator, ICategoryManager categoryManager, IRatingSettings settings)
        {
            this.videoRepo = videoRepo ?? throw new NullReferenceException();
            this.ratingRepo = _ratingRepo ?? throw new NullReferenceException();
            this.jsonReader = readerJson ?? throw new NullReferenceException();
            this.calculator = calculator ?? throw new NullReferenceException();
            this.categoryManager = categoryManager ?? throw new NullReferenceException();
            this.settings = settings ?? throw new NullReferenceException();
            writer = writerJson ?? throw new NullReferenceException();
        }

        public VideoManagementViewModel GetVideoManagementViewModel()
        {
            IList<VideoManagementViewModelGet> videos = new List<VideoManagementViewModelGet>();
            IEnumerable<ISearchVideo> vids = videoRepo.GetAll();
            IEnumerable<IDuncan> ratings = ratingRepo.GetAll();
            foreach (ISearchVideo video in vids)
            {
                VideoManagementViewModelGet model = new VideoManagementViewModelGet
                {
                    Video = video
                };
                IObjectPair<string, string> titleImage = jsonReader.GetVideoTitleAndImage(video.UrlIdentity);
                model.Title = titleImage.Object1;
                model.Thumbnail = titleImage.Object2;
                IEnumerable<IDuncan> videoRatings = ratings.Where(x => x.VideoIdentity == video.UrlIdentity);
                model.WatchCount = videoRatings.Count();
                if (model.WatchCount > 0)
                {
                    model.PleaureAverageAndDeviation = new ObjectPair<double, double>() { Object1 = videoRatings.Average(x => x.PleasureIndex), Object2 = calculator.Deviation(videoRatings.Select(x => x.PleasureIndex)) };
                    model.ArrouselAverageAndDeviation = new ObjectPair<double, double>() { Object1 = videoRatings.Average(x => x.ArrousalIndex), Object2 = calculator.Deviation(videoRatings.Select(x => x.ArrousalIndex)) };
                    model.DominanceAverageAndDeviation = new ObjectPair<double, double>() { Object1 = videoRatings.Average(x => x.DominanceIndex), Object2 = calculator.Deviation(videoRatings.Select(x => x.DominanceIndex)) };
                    IList<IObjectPair<string, int>> iabCategoriesNamesAndAverage = new List<IObjectPair<string, int>>();
                    IList<IObjectPair<int, int>> catCount = new List<IObjectPair<int, int>>();
                    foreach (int category in videoRatings.Select(x => x.CategoryID))
                    {
                        foreach (IObjectPair<int, int> catAndCount in catCount)
                        {
                            if (catAndCount.Object1 == category)
                            {
                                catAndCount.Object2 += 1;
                                break;
                            }

                        }
                        catCount.Add(new ObjectPair<int, int>() { Object1 = category, Object2 = 1 });
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        IEnumerable<IObjectPair<int, int>> currTierCounts = catCount.Where(x => categoryManager.IsTier(i, x.Object1));
                        if (currTierCounts.Count() > 0)
                        {
                            IObjectPair<int, int> biggestCat = currTierCounts.Where(x => x.Object2 == currTierCounts.Max(y => y.Object2)).First();
                            iabCategoriesNamesAndAverage.Add(new ObjectPair<string, int>() { Object1 = categoryManager.GetCategory(biggestCat.Object1).Name, Object2 = (int)Math.Round(biggestCat.Object2 / (double)currTierCounts.Sum(x => x.Object2), MidpointRounding.AwayFromZero) });
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                videos.Add(model);
            }
            return new VideoManagementViewModel() { Get = videos };
        }

        public byte[] ExportAllVideosToJson()
        {
            IEnumerable<IDuncan> duncans = ratingRepo.GetAllRatingFromFinishedVideos();
            string file = Path.GetFullPath(writer.Write(duncans).Result);
            byte[] bytes = File.ReadAllBytes(file);
            File.Delete(file);
            return bytes;
        }

        public bool ExpandJson(string filePath)
        {
            if (!jsonReader.CheckFileFormatting(filePath))
            {
                return false;
            }
            //add old to new replace old with new 
            //send new to db
            return true;
        }

        public void SetAlgoritmSensitiveness(AlgoritmSettingsModel model)
        {
            settings.IabToleranceTier1 = model.IabToleranceTier1 / 100;
            settings.IabToleranceTier2 = model.IabToleranceTier2 / 100;
            settings.MaximumRatings = model.MaximumRatings;
            settings.PadTolerance = model.PadTolerance;
                settings.BiggestPercentIAB = model.BiggestPercentIAB / 100;
        }

        public AlgoritmSettingsModel GetAlgoritmSettings()
        {
            return new AlgoritmSettingsModel()
            {
                IabToleranceTier1 = settings.IabToleranceTier1 * 100,
                IabToleranceTier2 = settings.IabToleranceTier2 * 100,
                MaximumRatings = settings.MaximumRatings,
                PadTolerance = settings.PadTolerance,
                BiggestPercentIAB = settings.BiggestPercentIAB * 100
            };
        }
    }
}
