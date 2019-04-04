using BusinessLogicLibrary.JsonReader;
using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public class AssignManager : IAssignManager
    {
        private readonly IVideoRepository videoRepo;

        public AssignManager(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
        }

        public Video AssignRandomVideo()
        {
            //JSON File de link van de video uithalen en het video id samen returnen in een viewmodel
            ReaderJson json = new ReaderJson();
            var video = ConvertHandler.ConvertTo<Video>(videoRepo.GetRandomVideo());
            video.VideoURL = json.GetVideoUrl(video.UrlIdentity);
            return video;
        }
    }
}
