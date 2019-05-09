using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model_Layer.Models
{
    public class Rating : IRating
    {
        [Key]
        public int RatingID { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public string VideoIdentity { get; set; }
        public Video Video { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool IsIABDivergent { get; set; }
        public int PleasureIndex { get; set; }
        public int ArrousalIndex { get; set; }
        public int DominanceIndex { get; set; }
        public bool IsPADDivergent { get; set; }
    }
}