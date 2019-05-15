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
        [Required(ErrorMessage = "Category is required")]
        public int IABID { get; set; }

        [Required(ErrorMessage = "Pleasure value is required"), Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int Pleasure { get; set; }

        [Required(ErrorMessage = "Arrousal value is required"), Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int Arrousal { get; set; }

        [Required(ErrorMessage = "Dominance value is required"), Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int Dominance { get; set; }
    }
}
