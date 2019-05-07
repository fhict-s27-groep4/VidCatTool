using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.AlgoritmRatings
{
    public class DivergentRatings : EventArgs
    {
        private IEnumerable<IRating> ratings;

        public DivergentRatings(IEnumerable<IRating> _ratings)
        {
            ratings = _ratings;
        }

        public IEnumerable<IRating> Ratings
        {
            get { return ratings; }
        }
    }
}
