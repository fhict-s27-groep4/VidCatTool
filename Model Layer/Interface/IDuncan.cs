using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface IDuncan
    {
        string UserID { get; set; }
        string VideoIdentity { get; set; }
        int CategoryID { get; set; }
        int PleasureIndex { get; set; }
        int ArrousalIndex { get; set; }
        int DominanceIndex { get; set; }
    }
}
