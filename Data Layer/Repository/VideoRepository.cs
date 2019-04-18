using Data_Layer.Interface;
using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Data_Layer.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(VidCatToolContext context) : base(context)
        {

        }

        public Video GetRandomVideo(string username)
        {
            var randomvid = _context.Video.FromSql("CALL GetRandomVideo(@username)", new MySqlParameter("@username", username));
            return randomvid.FirstOrDefault();
        }

        public Video GetVideoByUrlIdentity(string identity)
        {
            return _context.Video.Where(id => id.UrlIdentity == identity).FirstOrDefault();
        }
    }
}
