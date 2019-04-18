using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public class RatingManager
    {
        private readonly IRatingRepository ratingRepo;

        public RatingManager(IRatingRepository ratingRepo)
        {
            this.ratingRepo = ratingRepo;
        }

        public void AddRating(string userid, int videoid, int categoryid, int pleasure, int arrousal, int dominance)
        {
            ratingRepo.AddRating(userid, videoid, categoryid, pleasure, arrousal, dominance);
        }
    }
}
