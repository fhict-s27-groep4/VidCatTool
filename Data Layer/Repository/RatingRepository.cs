using Data_Layer.Interface;
using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repository
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(VidCatToolContext context) : base(context)
        {

        }

        public IEnumerable<Rating> GetAllRatings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetRatingByID()
        {
            throw new NotImplementedException();
        }
    }
}
