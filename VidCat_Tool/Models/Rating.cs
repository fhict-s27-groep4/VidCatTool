using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VidCat_Tool.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public int VideoID { get; set; }
        //public Video Video { get; set; }
        public int CategoryID { get; set; }
        //public Category Category { get; set; }
        public bool IsDivergent { get; set; }
        public int PleasureIndex { get; set; }
        public int ArrousalIndex { get; set; }
        public int DominanceIndex { get; set; }
    }
}
