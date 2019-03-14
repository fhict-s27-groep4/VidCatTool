using Data_Layer.Interface;
using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(VidCatToolContext context) : base(context)
        {

        }
    }
}
