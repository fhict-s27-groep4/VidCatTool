using Data_Layer.Interface;
using Service_Layer.ViewModels;
using Service_Layer.SessionExtension;
using Model_Layer.Interface;
using System.Linq;
using Logic_Layer.AlgoritmRatings;
using System.Threading.Tasks;

namespace Service_Layer.RequestHandlers
{
    public class RatingHandler
    {
        private readonly IRatingRepository ratingRepo;
        private readonly IVideoRepository videoRepo;
        private readonly SessionHandler sessionHandler;
        private readonly RatingAlgoritm ratingAlgoritm;

        public RatingHandler(IRatingRepository ratingRepo, IVideoRepository videoRepo, SessionHandler sessionHandler, RatingAlgoritm _ratingAlgoritm)
        {
            this.ratingRepo = ratingRepo;
            this.videoRepo = videoRepo;
            this.sessionHandler = sessionHandler;
            ratingAlgoritm = _ratingAlgoritm;
            ratingAlgoritm.DivergentRatings += this.OnDivergentRatings;
        }

        private void OnDivergentRatings(object sender, DivergentRatings e)
        {
            
        }

        public void AddRating(ReviewViewModel vm)
        {
            ratingRepo.AddRating(sessionHandler.Session.GetUserIDKey(), videoRepo.GetVideoID(vm.VideoIdentity), 5, vm.Pleasure, vm.Arrousal, vm.Dominance);
            Task.Run(() => ratingAlgoritm.FindDivergents(ratingRepo.GetRatingsByVideoID(vm.)));
        }
    }
}
