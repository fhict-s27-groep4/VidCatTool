using Data_Layer.Interface;
using Model_Layer.Models;
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
