using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model_Layer.Models
{
    public class Category : ICategory
    {
        [Key]
        public int UniqueID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
