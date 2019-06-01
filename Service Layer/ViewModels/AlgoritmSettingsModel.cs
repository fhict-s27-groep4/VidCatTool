using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class AlgoritmSettingsModel
    {
        private double iabTolerance1;
        private double iabTolerance2;
        private double biggestpercentage;

        public double IabToleranceTier1
        {
            get { return iabTolerance1 * 100; }
            set { iabTolerance1 = value / 100; }
        }
        public double IabToleranceTier2
        {
            get { return iabTolerance2 * 100; }
            set { iabTolerance2 = value / 100; }
        }
        public double BiggestPercentIAB
        {
            get { return biggestpercentage * 100; }
            set { biggestpercentage = value / 100; }
        }
        public double PadTolerance { get; set; }
        public int MaximumRatings { get; set; }
    }
}
