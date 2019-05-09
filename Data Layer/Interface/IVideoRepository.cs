using Model_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Interface
{
    public interface IVideoRepository : IRepository<Video>
    {
        Video GetRandomVideo(string username);
    }
}
