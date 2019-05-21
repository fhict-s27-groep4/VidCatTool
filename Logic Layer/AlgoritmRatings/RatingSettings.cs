using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.AlgoritmRatings
{
    public class RatingSettings : IRatingSettings
    {
        public RatingSettings()
        {

        }
        public double IabToleranceTier1 { get; set; }
        public double IabToleranceTier2 { get; set; }
        public double BiggestPercentIAB { get; set; }
        public double PadTolerance { get; set; }
        public int MaximumRatings { get; set; }
    }
}
