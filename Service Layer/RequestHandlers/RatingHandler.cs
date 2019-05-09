using Data_Layer.Interface;
using Service_Layer.ViewModels;
using Service_Layer.SessionExtension;
using Model_Layer.Interface;
using System.Linq;
using Logic_Layer.AlgoritmRatings;
using System.Threading.Tasks;
using Logic_Layer.CategoryReverser;

namespace Service_Layer.RequestHandlers
{
    public class RatingHandler
    {
        private readonly IRatingRepository ratingRepo;
        private readonly IVideoRepository videoRepo;
        private readonly SessionHandler sessionHandler;
        private readonly ICategoryRepository categoryRepo;
        private readonly RatingAlgoritm ratingAlgoritm;

        public RatingHandler(IRatingRepository ratingRepo, IVideoRepository videoRepo, ICategoryRepository categoryRepo, SessionHandler sessionHandler)
        {
            this.ratingRepo = ratingRepo;
            this.videoRepo = videoRepo;
            this.sessionHandler = sessionHandler;
            this.categoryRepo = categoryRepo;
            ratingAlgoritm = new RatingAlgoritm(new CategroyReverser(categoryRepo.GetAll()));
            ratingAlgoritm.DivergentRatings += this.OnDivergentRatings;
        }

        private void OnDivergentRatings(object sender, DivergentRatings e)
        {
            
        }

        public void AddRating(ReviewViewModel vm)
        {
            ratingRepo.AddRating(sessionHandler.Session.GetUserIDKey(), vm.VideoIdentity, 5, vm.Pleasure, vm.Arrousal, vm.Dominance);
            ratingAlgoritm.FindDivergents(ratingRepo.GetRatingsByVideoID(vm.VideoIdentity).Result);
        }
    }
}
