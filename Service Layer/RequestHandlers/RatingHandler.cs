using Data_Layer.Interface;
using Service_Layer.ViewModels;
using Service_Layer.SessionExtension;
using Model_Layer.Interface;
using System.Linq;
using Logic_Layer.AlgoritmRatings;
using System.Threading.Tasks;
using Logic_Layer.CategoryReverser;
using System;

namespace Service_Layer.RequestHandlers
{
    public class RatingHandler
    {
        private readonly IRatingRepository ratingRepo;
        private readonly IVideoRepository videoRepo;
        private readonly SessionHandler sessionHandler;
        private readonly ICategoryRepository categoryRepo;
        private readonly IRatingAlgoritm ratingAlgoritm;

        public RatingHandler(IRatingRepository ratingRepo, IVideoRepository videoRepo, ICategoryRepository categoryRepo, SessionHandler sessionHandler, IRatingAlgoritm _ratingAlgoritm)
        {
            this.ratingRepo = ratingRepo ?? throw new NullReferenceException();
            this.videoRepo = videoRepo ?? throw new NullReferenceException();
            this.sessionHandler = sessionHandler ?? throw new NullReferenceException();
            this.categoryRepo = categoryRepo ?? throw new NullReferenceException();
            this.ratingAlgoritm = _ratingAlgoritm ?? throw new NullReferenceException();
            this.ratingAlgoritm.DivergentRatings += this.OnDivergentRatings;
        }

        private void OnDivergentRatings(object sender, DivergentRatings e)
        {
            videoRepo.UpdateVideoFinished(e.VidID);
            foreach (IRating r in e.Ratings.Where(x => x.IsPADDivergent))
            {
                ratingRepo.UpdatePadDivergent(r);
            }
            foreach (IRating r in e.Ratings.Where(x => x.IsIABDivergent))
            {
                ratingRepo.UpdateIABDivergent(r);
            }
        }

        public void AddRating(ReviewViewModelPost vm)
        {
            ratingRepo.AddRating(sessionHandler.Session.GetUserIDKey(), vm.VideoIdentity, vm.IABID, vm.Pleasure, vm.Arrousal, vm.Dominance);
            Task.Run(() => ratingAlgoritm.FindDivergents(ratingRepo.GetRatingsByVideoID(vm.VideoIdentity))); 
        }
    }
}
