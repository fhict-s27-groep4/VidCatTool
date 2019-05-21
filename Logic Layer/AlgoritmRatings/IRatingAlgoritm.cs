using System;
using System.Collections.Generic;
using Model_Layer.Interface;

namespace Logic_Layer.AlgoritmRatings
{
    public interface IRatingAlgoritm
    {
        event EventHandler<DivergentRatings> DivergentRatings;

        void FindDivergents(IEnumerable<IRating> _ratings);
    }
}