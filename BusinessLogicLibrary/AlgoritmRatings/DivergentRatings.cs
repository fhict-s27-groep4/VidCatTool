using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary.AlgoritmRatings
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
