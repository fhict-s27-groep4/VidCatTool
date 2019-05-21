using Data_Layer.Interface;
using Logic_Layer.CategoryReverser;
using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ServiceCollector
{
    public class AllCategories : IAllCategories
    {
        public AllCategories(ICategoryRepository categoryRepository)
        {
            Categories = categoryRepository.GetAll();
        }
        public IEnumerable<ICategory> Categories { get; private set; }
    }
}
