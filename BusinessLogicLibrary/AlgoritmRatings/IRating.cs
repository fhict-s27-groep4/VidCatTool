using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary.AlgoritmRatings
{
    public interface IRating
    {
        int Catagory1 { get; }
        int Catagory2 { get; }
        bool IABIsDivergent { get; set; }
        int Pleasure { get; }
        int Arrousel { get; }
        int Dominance { get; }
        bool PADIsDivergent { get; set; }
    }
}
