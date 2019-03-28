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
        public int VideoID { get; set; }
        [Required]
        public int IABID { get; set; }
        [Required]
        public int Pleasure { get; set; }
        [Required]
        public int Arrousal { get; set; }
        [Required]
        public int Dominance { get; set; }
    }
}
