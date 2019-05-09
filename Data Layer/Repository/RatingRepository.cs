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
        public RatingRepository(VidCatToolContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Rating>> GetAllRatings()
        {
            return await _context.Rating.Include(x => x.Category).ThenInclude(x => x.UniqueID).Include(x => x.User).ThenInclude(x => x.UserID).Include(v => v.Video).ThenInclude(v => v.UrlIdentity).ToListAsync();
        }

        // Untested
        public async Task<Rating> GetRatingByID(int id)
        {
            return await _context.Rating.FindAsync(id);
        }

        // Untested
        public async Task<IEnumerable<Rating>> GetRatingsFromUser(string username)
        {
            return await _context.Rating.Where(u => u.User.Username == username).ToListAsync();
        }

        public void AddRating(string userid, string videoidentity, int categoryid, int pleasure, int arrousal, int dominance)
        {
            _context.Database.ExecuteSqlCommand("CALL AddRating(@userid, @videoid, @categoryid, @pleasure, @arrousal, @dominance)", new MySqlParameter("@userid", userid),
                new MySqlParameter("@videoid", videoidentity), new MySqlParameter("@categoryid", categoryid), new MySqlParameter("@pleasure", pleasure),
                new MySqlParameter("@arrousal", arrousal), new MySqlParameter("@dominance", dominance));
        }

        public async Task<IEnumerable<Rating>> GetRatingsByVideoID(string videoid)
        {
            return await _context.Rating.Where(video => video.VideoIdentity == videoid).ToListAsync();
        }
    }
}
