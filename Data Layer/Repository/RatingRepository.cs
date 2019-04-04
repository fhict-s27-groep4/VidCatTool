using Data_Layer.Interface;
using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data_Layer.Repository
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(VidCatToolContext context) : base(context)
        {

        }

        // Untested
        public async Task<IEnumerable<Rating>> GetAllRatings()
        {
            return await _context.Rating.Include(x => x.Category).ThenInclude(x => x.UniqueID).Include(x => x.User).ThenInclude(x => x.UserID).Include(v => v.Video).ThenInclude(v => v.VideoID).ToListAsync();
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
    }
}
