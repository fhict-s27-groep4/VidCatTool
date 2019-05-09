using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.AlgoritmRatings
{
    public interface IRating
    {
        int Category1 { get; }
        int Category2 { get; }
        bool IsIABDivergent { get; set; }
        int PleasureIndex { get; }
        int ArrousalIndex { get; }
        int DominanceIndex { get; }
        bool IsPADDivergent { get; set; }
    }
}
