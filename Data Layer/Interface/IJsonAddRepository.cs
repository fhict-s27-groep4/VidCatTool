using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Interface
{
    public interface IJsonAddRepository : IRepository<string>
    {
        void AddJsonVideos(IEnumerable<string> ids);
    }
}
