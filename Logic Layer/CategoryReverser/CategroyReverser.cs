using Model_Layer.Interface;
using System.Collections.Generic;

namespace Logic_Layer.CategoryReverser
{
    public class CategroyReverser
    {
        IEnumerable<IRating> ratings;
        public CategroyReverser(IEnumerable<IRating> _ratings)
        {
            ratings = _ratings;
        }

        public IObjectPair<int, int> GetParentTiers(ICategory _category)
        {
            IObjectPair<int, int> parentTiers = new ObjectPair<int, int>();
            parentTiers.Object1 = _category.ParentID;
            parentTiers.Object1 = _category.UniqueID;
            ICategory current = _category;
            while(current.ParentID)
            return parentTiers;
        }
    }
}
