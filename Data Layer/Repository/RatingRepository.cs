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
        public RatingRepository(IDBContext context) : base(context)
        {

        }

        public void AddRating(string userid, string videoidentity, int categoryid, int pleasure, int arrousal, int dominance)
        {
            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@userId", userid);
            parameters[1] = new MySqlParameter("@videoId", videoidentity);
            parameters[2] = new MySqlParameter("@categoryID", categoryid);
            parameters[3] = new MySqlParameter("@pleasure", pleasure);
            parameters[4] = new MySqlParameter("@arrousal", arrousal);
            parameters[5] = new MySqlParameter("@dominance", dominance);
            context.ExecuteStoredProcedure("AddRating", parameters);
        }
        

        public IEnumerable<Rating> GetRatingsByVideoID(string videoid)
        {
            return context.SelectQuery<Rating>().Where(rating => rating.VideoIdentity == videoid);
        }
        
    }
}
