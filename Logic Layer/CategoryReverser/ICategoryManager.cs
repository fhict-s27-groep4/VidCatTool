using System.Collections.Generic;
using Model_Layer.Interface;

namespace Logic_Layer.CategoryReverser
{
    public interface ICategoryManager
    {
        IEnumerable<ICategory> GetAllTierOne();
        IObjectPair<int, int> GetParentTiers(int _categoryID);
        IEnumerable<ICategory> GetSubTiers(int parentCategory);
    }
}