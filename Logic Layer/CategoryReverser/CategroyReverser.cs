using Model_Layer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Logic_Layer.CategoryReverser
{
    public class CategroyReverser
    {
        IEnumerable<ICategory> categories;
        public CategroyReverser(IEnumerable<ICategory> _categories)
        {
            categories = _categories;
        }

        public IObjectPair<int, int> GetParentTiers(ICategory _category)
        {
            IObjectPair<int, int> parentTiers = new ObjectPair<int, int>();
            parentTiers.Object1 = (int)_category.ParentID;
            parentTiers.Object1 = _category.UniqueID;
            ICategory current = _category;
            while(current.ParentID != null)
            {
                current = categories.Where(x => x.UniqueID == parentTiers.Object1).First();
                parentTiers.Object1 = (int)current.ParentID;
                parentTiers.Object1 = current.UniqueID;
            }
            return parentTiers;
        }
    }
}
