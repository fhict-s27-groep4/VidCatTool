using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface IRating : IDuncan
    {

        bool IsIABDivergent { get; set; }
        bool IsPADDivergent { get; set; }
    }
}
