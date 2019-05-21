using Data_Layer.Interface;
using Logic_Layer.CategoryReverser;
using Model_Layer.Interface;
using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.RequestHandlers
{
    public class CategoryHandler
    {
        private readonly ICategoryManager categoryManager;
        public CategoryHandler(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public ReviewViewModel GetTier1s()
        {
            ReviewViewModel rVM = new ReviewViewModel();
            rVM.Get.Categories = categoryManager.GetAllTierOne();
            return rVM;
        }

        public IEnumerable<ICategory> GetSubTiers(int _categoryID)
        {
            return categoryManager.GetSubTiers(_categoryID);
        }
    }
}
