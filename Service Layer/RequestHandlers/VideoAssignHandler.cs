using Data_Layer.Interface;
using Logic_Layer.JsonReader;
using Model_Layer.Interface;

namespace Service_Layer.RequestHandlers
{
    public class VideoAssignHandler
    {
        private readonly IVideoRepository videoRepo;
        public VideoAssignHandler(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
        }

        // Return een ViewModel die deze informatie bevat
        public IVideo AssignRandomVideo(string username)
        {
            return videoRepo.GetRandomVideo(username);
        }

        public string GetVideoLink(string videoIdentity)
        {
            ReaderJson reader = new ReaderJson();
            return reader.GetVideoUrl(videoIdentity);
        }
    }
}
