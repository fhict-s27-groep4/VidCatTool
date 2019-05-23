using Data_Layer.Interface;
using Logic_Layer.AlgoritmRatings;
using Logic_Layer.CategoryReverser;
using Logic_Layer.JsonReader;
using Logic_Layer.JsonWriter;
using Logic_Layer.Maths;
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

        public VideoHandler(IVideoRepository videoRepo, IRatingRepository _ratingRepo, IReaderJson readerJson, IWriterJson writerJson, ICalculator calculator)
        {
            this.videoRepo = videoRepo ?? throw new NullReferenceException();
            this.ratingRepo = _ratingRepo ?? throw new NullReferenceException();
            this.jsonReader = readerJson ?? throw new NullReferenceException();
            this.calculator = calculator ?? throw new NullReferenceException();
            writer = writerJson ?? throw new NullReferenceException();
        }

        public IEnumerable<VideoManagementViewModel> GetVideoManagementViewModel()
        {
            IList<VideoManagementViewModel> videos = new List<VideoManagementViewModel>();
            IEnumerable<ISearchVideo> vids = videoRepo.GetAll();
            IEnumerable<IRating> ratings = ratingRepo.GetAll();
            foreach (ISearchVideo video in vids)
            {
                VideoManagementViewModel model = new VideoManagementViewModel();
                model.Video = video;
                IObjectPair<string, string> titleImage = jsonReader.GetVideoTitleAndImage(video.UrlIdentity);
                model.Title = titleImage.Object1;
                model.Thumbnail = titleImage.Object2;
                IEnumerable<IRating> videoRatings = ratings.Where(x => x.VideoIdentity == video.UrlIdentity);
                model.WatchCount = videoRatings.Count();
                model.PleaureAverageAndDeviation = new ObjectPair<double, double>() { Object1 = videoRatings.Average(x => x.PleasureIndex), Object2 = calculator.Deviation(videoRatings.Select(x => x.PleasureIndex)) };
                model.ArrouselAverageAndDeviation = new ObjectPair<double, double>() { Object1 = videoRatings.Average(x => x.ArrousalIndex), Object2 = calculator.Deviation(videoRatings.Select(x => x.ArrousalIndex)) };
                model.DominanceAverageAndDeviation = new ObjectPair<double, double>() { Object1 = videoRatings.Average(x => x.DominanceIndex), Object2 = calculator.Deviation(videoRatings.Select(x => x.DominanceIndex)) };
                videos.Add(model);
            }
            return videos;
        }

        public byte[] ExportAllVideosToJson()
        {
            IEnumerable<IDuncan> duncans = ratingRepo.GetAllRatingFromFinishedVideos();
            string file = Path.GetFullPath(writer.Write(duncans).Result);
            byte[] bytes = File.ReadAllBytes(file);
            File.Delete(file);
            return bytes;
        }
    }
}
