using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public void AddRating(string userid, string videoidentity, int categoryid, int pleasure, int arrousal, int dominance)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> GetAllRatings()
        {
            throw new NotImplementedException();
        }

        public Task<Rating> GetRatingByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> GetRatingsByVideoID(string videoid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> GetRatingsFromUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
