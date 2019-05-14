using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class ReviewViewModelPost
    {
        [Required]
        public string VideoIdentity { get; set; }
        [Required]
        public int IABID { get; set; }
        [Required]
        [Range(1, 5)]
        public int Pleasure { get; set; }
        [Required]
        [Range(1, 5)]
        public int Arrousal { get; set; }
        [Required]
        [Range(1, 5)]
        public int Dominance { get; set; }
    }
}
