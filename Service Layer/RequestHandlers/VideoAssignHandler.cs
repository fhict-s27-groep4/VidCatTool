using Data_Layer.Interface;
using Logic_Layer.JsonReader;
using Model_Layer.Interface;
using System;

namespace Service_Layer.RequestHandlers
{
    public class VideoAssignHandler
    {
        private readonly IReaderJson reader;
        private readonly IVideoRepository videoRepo;
        public VideoAssignHandler(IVideoRepository videoRepo, IReaderJson readerJson)
        {
            this.videoRepo = videoRepo ?? throw new NullReferenceException();
            this.reader = readerJson ?? throw new NullReferenceException();
        }
        public IVideo AssignRandomVideo(string username)
        {
            return videoRepo.GetRandomVideo(username);
        }

        public string GetVideoLink(string videoIdentity)
        {
            return reader.GetVideoUrl(videoIdentity);
        }
    }
}
