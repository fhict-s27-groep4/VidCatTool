using Data_Layer.Interface;
using Logic_Layer.AlgoritmRatings;
using Logic_Layer.CategoryReverser;
using Logic_Layer.JsonReader;
using Logic_Layer.JsonWriter;
using Model_Layer.Interface;
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
        private readonly IRatingAlgoritm ratingAlgoritm;
        private readonly WriterJson writer;

        public VideoHandler(IVideoRepository videoRepo, IRatingRepository _ratingRepo, IRatingAlgoritm ratingAlgoritm)
        {
            this.videoRepo = videoRepo;
            this.ratingRepo = _ratingRepo;
            this.ratingAlgoritm = ratingAlgoritm;
            throw new NotImplementedException();
            //writer = new WriterJson();
        }

        public IEnumerable<VideoManagementViewModel> GetVideoManagementViewModel()
        {
            ReaderJson reader = new ReaderJson();
            IList<VideoManagementViewModel> videos = new List<VideoManagementViewModel>();
            IEnumerable<ISearchVideo> vids = videoRepo.GetAll();
            IEnumerable<IRating> ratings = ratingRepo.GetAll();
            foreach (ISearchVideo video in vids)
            {
                VideoManagementViewModel model = new VideoManagementViewModel();
                model.Video = video;
                IObjectPair<string, string> titleImage = reader.GetVideoTitleAndImage(video.UrlIdentity);
                model.Title = titleImage.Object1;
                model.Thumbnail = titleImage.Object2;
                model.WatchCount = ratings.Where(x => x.VideoIdentity == video.UrlIdentity).Count();
                IList<IObjectPair<int, int>> catCount = new List<IObjectPair<int, int>>();
                foreach (IRating rating in ratings.Where(x => x.VideoIdentity == video.UrlIdentity))
                {
                    throw new NotImplementedException();
                    //catCount = ratingAlgoritm.CatagoryInList(catCount, categoryManager.GetParentTiers(rating.CategoryID).Object2);
                }
                if (catCount.Count() > 0)
                {
                    model.BiggestTier2 = (catCount.Max(x => x.Object2) / (double)model.WatchCount) * (double)100;
                }
                else
                {
                    model.BiggestTier2 = 0;
                }
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
