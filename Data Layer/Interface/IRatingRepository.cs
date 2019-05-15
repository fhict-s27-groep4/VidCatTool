using Model_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interface
{
    public interface IRatingRepository : IRepository<Rating>
    {
        void AddRating(string userid, string videoidentity, int categoryid, int pleasure, int arrousal, int dominance);

        IEnumerable<Rating> GetRatingsByVideoID(string videoid);

        void UpdateIABDivergent(IRating rating);

        void UpdatePadDivergent(IRating rating);

        IEnumerable<IDuncan> GetAllRatingFromFinishedVideos();
    }
}
