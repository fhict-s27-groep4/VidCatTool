using Data_Layer.Interface;
using Logic_Layer.JsonReader;
using Model_Layer.Interface;

namespace Service_Layer.RequestHandlers
{
    public class VideoAssignHandler
    {
        private readonly ReaderJson reader;
        private readonly IVideoRepository videoRepo;
        public VideoAssignHandler()
        {
            reader = new ReaderJson();
        }
        public VideoAssignHandler(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
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
