using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary.AlgoritmRatings
{
    public interface IObjectPair<T1, T2>
    {
        T1 Object1 { get; set; }
        T2 Object2 { get; set; }
    }
}
