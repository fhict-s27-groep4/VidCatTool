using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.AlgoritmRatings
{
    public class DivergentRatings : EventArgs
    {
        private string vidID;
        private IEnumerable<IRating> ratings;

        public DivergentRatings(string _vidID, IEnumerable<IRating> _ratings)
        {
            vidID = _vidID;
            ratings = _ratings;
        }

        public string VidID
        {
            get { return vidID; }
        }

        public IEnumerable<IRating> Ratings
        {
            get { return ratings; }
        }
    }
}
