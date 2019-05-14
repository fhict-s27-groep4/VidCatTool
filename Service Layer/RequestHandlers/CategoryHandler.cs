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
        private readonly CategoryManager categoryManager;
        public CategoryHandler(IEnumerable<ICategory> _categories)
        {
            categoryManager = new CategoryManager(_categories);
        }

        public ReviewViewModel GetTier1s()
        {
            ReviewViewModel rVM = new ReviewViewModel();
            rVM.Get.Categories = categoryManager.GetAllTierOne();
            return rVM;
        }

        public ReviewViewModel GetSubTiers(int _categoryID)
        {
            ReviewViewModel rVM = new ReviewViewModel();
            rVM.Get.Categories = categoryManager.GetSubTiers(_categoryID);
            return rVM;
        }
    }
}
