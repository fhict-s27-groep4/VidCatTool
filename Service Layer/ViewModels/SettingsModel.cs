using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class SettingsModel
    {
        private double iabTolerance1;
        private double iabTolerance2;
        private double biggestpercentage;

        [Required, Display(Name = "IabToleranceTier1", Prompt = "IabToleranceTier1")]
        public double IabToleranceTier1
        {
            get { return iabTolerance1 * 100; }
            set { iabTolerance1 = value / 100; }
        }
        [Required, Display(Name = "IabToleranceTier2", Prompt = "IabToleranceTier2")]
        public double IabToleranceTier2
        {
            get { return iabTolerance2 * 100; }
            set { iabTolerance2 = value / 100; }
        }
        [Required, Display(Name = "BiggestPercentIAB", Prompt = "BiggestPercentIAB")]
        public double BiggestPercentIAB
        {
            get { return biggestpercentage * 100; }
            set { biggestpercentage = value / 100; }
        }
        [Required, Display(Name = "PadTolerance", Prompt = "PadTolerance")]
        public double PadTolerance { get; set; }
        [Required, Display(Name = "MaximumRatings", Prompt = "MaximumRatings")]
        public int MaximumRatings { get; set; }
        public MailSettings MailSettings { get; set; }
        public MailContent NewUser { get; set; }
        public MailContent ResetPassword { get; set; }
    }
}
