using Data_Layer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer.Repository
{
    public class UserStatsRepository : Repository<UserStats>, IUserStatsRepository
    {
        public UserStatsRepository(IDBContext context) : base(context)
        {
        }

        public UserStats GetUserStats(string userID)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("@userid", userID) };
            return context.ExecuteReturnStoredProcedure<UserStats>("GetUserStats", parameters).FirstOrDefault();
        } 
    }

    public class UserStats
    {
        public Int64 TotalVideos { get; set; }
        public Int64 FinishedVideos { get; set; }
        public decimal AverageViewedVideos { get; set; }
        public Int64 ViewCount { get; set; }
    }
}
