using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface IRating
    {
        int CategoryID { get; set; }
        bool IsIABDivergent { get; set; }
        int PleasureIndex { get; set; }
        int ArrousalIndex { get; set; }
        int DominanceIndex { get; set; }
        bool IsPADDivergent { get; set; }
    }
}
