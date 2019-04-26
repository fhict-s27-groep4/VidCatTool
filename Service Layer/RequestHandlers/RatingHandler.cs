using Data_Layer.Interface;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Service_Layer.SessionExtension;

namespace Service_Layer.RequestHandlers
{
    public class RatingHandler
    {
        private readonly IRatingRepository ratingRepo;
        private readonly IVideoRepository videoRepo;
        private readonly SessionHandler sessionHandler;

        public RatingHandler(IRatingRepository ratingRepo, IVideoRepository videoRepo, SessionHandler sessionHandler)
        {
            this.ratingRepo = ratingRepo;
            this.videoRepo = videoRepo;
            this.sessionHandler = sessionHandler;
        }

        public void AddRating(ReviewViewModel vm)
        {
            ratingRepo.AddRating(sessionHandler.Session.GetUserIDKey(), videoRepo.GetVideoID(vm.VideoIdentity), 5, vm.Pleasure, vm.Arrousal, vm.Dominance);
        }
    }
}
