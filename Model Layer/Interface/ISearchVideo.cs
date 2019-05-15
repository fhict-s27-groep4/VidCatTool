using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface ISearchVideo : IVideo
    {
        bool Finished { get; }
    }
}
