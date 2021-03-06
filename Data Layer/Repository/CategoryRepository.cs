﻿using Data_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(IDBContext context) : base(context)
        {

        }
    }
}
