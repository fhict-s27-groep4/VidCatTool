using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VidCat_Tool.ViewModels
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
