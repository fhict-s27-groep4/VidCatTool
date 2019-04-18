using BusinessLogicLibrary.JsonReader;
using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public class AssignManager
    {
        private readonly IVideoRepository videoRepo;

        public AssignManager(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
        }

        public Video AssignRandomVideo(string username)
        {
            //JSON File de link van de video uithalen en het video id samen returnen in een viewmodel
            ReaderJson json = new ReaderJson();
            var video = ConvertHandler.ConvertTo<Video>(videoRepo.GetRandomVideo(username));
            video.VideoURL = json.GetVideoUrl(video.UrlIdentity);
            return video;
        }

        public Video GetVideo(string videourl)
        {
            return ConvertHandler.ConvertTo<Video>(videoRepo.GetVideoByUrlIdentity(videourl));
        }
    }
}
