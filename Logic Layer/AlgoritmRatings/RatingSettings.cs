using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic_Layer.AlgoritmRatings
{
    public class RatingSettings : IRatingSettings
    {
        public RatingSettings()
        {
            IabToleranceTier1 = 1;
            IabToleranceTier2 = 1;
            BiggestPercentIAB = 0;
            PadTolerance = 5;
            MaximumRatings = int.MaxValue;
        }
        [Required, Display(Name = "IabToleranceTier1", Prompt = "IabToleranceTier1")]
        public double IabToleranceTier1 { get; set; }
        [Required, Display(Name = "IabToleranceTier2", Prompt = "IabToleranceTier2")]
        public double IabToleranceTier2 { get; set; }
        [Required, Display(Name = "BiggestPercentIAB", Prompt = "BiggestPercentIAB")]
        public double BiggestPercentIAB { get; set; }
        [Required, Display(Name = "PadTolerance", Prompt = "PadTolerance")]
        public double PadTolerance { get; set; }
        [Required, Display(Name = "MaximumRatings", Prompt = "MaximumRatings")]
        public int MaximumRatings { get; set; }
    }
}
