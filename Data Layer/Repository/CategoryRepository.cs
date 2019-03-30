using Data_Layer.Interface;
using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(VidCatToolContext context) : base(context)
        {

        }
    }
}
