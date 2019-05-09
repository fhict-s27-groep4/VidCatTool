using Model_Layer.Models;
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

        void AddRating(string userid, string videoidentity, int categoryid, int pleasure, int arrousal, int dominance);

        Task<IEnumerable<Rating>> GetRatingsByVideoID(string videoid);
    }
}
