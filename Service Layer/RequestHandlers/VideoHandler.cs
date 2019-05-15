using Data_Layer.Interface;
using Logic_Layer.JsonWriter;
using Model_Layer.Interface;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.RequestHandlers
{
    public class VideoHandler
    {
        private readonly IVideoRepository videoRepo;
        private readonly IRatingRepository ratingRepo;
        private readonly WriterJson writer;

        public VideoHandler(IVideoRepository videoRepo, IRatingRepository _ratingRepo, ICategoryRepository _catRepo)
        {
            this.videoRepo = videoRepo;
            this.ratingRepo = _ratingRepo;
            writer = new WriterJson(new Logic_Layer.CategoryReverser.CategoryManager(_catRepo.GetAll()));
        }

        public VideoManagementViewModel GetVideoManagementViewModel()
        {
            VideoManagementViewModel vm = new VideoManagementViewModel();
            vm.Videos = videoRepo.GetAll() as IReadOnlyCollection<ISearchVideo>;
            return vm;
        }

        public string ExportAllVideosToJson()
        {
            IEnumerable<IDuncan> duncans = ratingRepo.GetAllRatingFromFinishedVideos();
            return writer.Write(duncans).Result;
        }
    }
}
