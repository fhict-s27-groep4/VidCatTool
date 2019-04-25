using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model_Layer.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public string UrlIdentity { get; set; }
        public bool Finished { get; set; }
        public ICollection<Rating> Ratings { get; set; }

    }
}
