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

        public IObjectPair<int, int> GetParentTiers(int _categoryID)
        {
            IObjectPair<int, int> parentTiers = new ObjectPair<int, int>();
            ICategory current = categories.Where(x => x.UniqueID == _categoryID).First();
            while(current.ParentID != null)
            {
                parentTiers.Object1 = (int)current.ParentID;
                parentTiers.Object1 = current.UniqueID;
                current = categories.Where(x => x.UniqueID == parentTiers.Object1).First();
            }
            return parentTiers;
        }
    }
}
