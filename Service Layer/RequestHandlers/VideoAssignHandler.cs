using Data_Layer.Interface;
using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.RequestHandlers
{
    public class VideoAssignHandler
    {
        private readonly IVideoRepository videoRepo;
        public VideoAssignHandler(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
        }

        public IAssignVideo GetRandomVideo(string username)
        {
            return (IAssignVideo)videoRepo.GetRandomVideo(username);
        }
    }
}
