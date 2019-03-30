using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Layer.Model
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int VideoID { get; set; }
        public Video Video { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool IsDivergent { get; set; }
        public int PleasureIndex { get; set; }
        public int ArrousalIndex { get; set; }
        public int DominanceIndex { get; set; }
    }
}
