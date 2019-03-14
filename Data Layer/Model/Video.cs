using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Layer.Model
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public int UrlIdentity { get; set; }
        public ICollection<Rating> Ratings { get; set; }

    }
}
