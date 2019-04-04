using Data_Layer.Interface;
using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data_Layer.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(VidCatToolContext context) : base(context)
        {

        }

        public Video GetRandomVideo()
        {
           var videos = _context.Video.Include(x => x.Ratings);
           return videos.Where(count => count.Ratings.Count < 3).OrderByDescending(count => count.Ratings.Count).FirstOrDefault();
        }
    }
}
