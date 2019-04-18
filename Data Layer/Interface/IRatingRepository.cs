using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interface
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<IEnumerable<Rating>> GetAllRatings();

        Task<Rating> GetRatingByID(int id);

        Task<IEnumerable<Rating>> GetRatingsFromUser(string username);

        void AddRating(string userid, int videoid, int categoryid, int pleasure, int arrousal, int dominance);
    }
}
