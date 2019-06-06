using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Interface
{
    public interface IJsonAddRepository : IRepository<AddJson>
    {
        void AddJsonVideos(IEnumerable<AddJson> ids);
    }
}
