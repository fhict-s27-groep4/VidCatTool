using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Interface
{
    public interface IRatingRepository : IRepository<Rating>
    {
        IEnumerable<Rating> GetAllRatings();

        IEnumerable<Rating> GetRatingByID();
    }
}
