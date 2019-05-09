using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using Model_Layer.Interface;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public Video GetRandomVideo(string username)
        {
            throw new NotImplementedException();
        }
    }
}
