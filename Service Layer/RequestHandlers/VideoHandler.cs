using Data_Layer.Interface;
using Model_Layer.Interface;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.RequestHandlers
{
    public class VideoHandler
    {
        private readonly IVideoRepository videoRepo;

        public VideoHandler(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
        }

        public VideoManagementViewModel GetVideoManagementViewModel()
        {
            VideoManagementViewModel vm = new VideoManagementViewModel();
            vm.Videos = videoRepo.GetAll() as IReadOnlyCollection<ISearchVideo>;
            return vm;
        }
    }
}
