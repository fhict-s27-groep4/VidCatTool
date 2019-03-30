﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Model
{
    public class Category
    {
        public int UniqueID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}