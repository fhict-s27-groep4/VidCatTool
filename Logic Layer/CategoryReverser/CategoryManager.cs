using Model_Layer.Interface;
using Model_Layer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic_Layer.CategoryReverser
{
    public class CategoryManager : ICategoryManager
    {
        private IEnumerable<ICategory> categories;
        public CategoryManager(IEnumerable<ICategory> _categories)
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
                parentTiers.Object2 = current.UniqueID;
                current = categories.Where(x => x.UniqueID == parentTiers.Object1).First();
            }
            return parentTiers;
        }

        public IEnumerable<ICategory> GetAllTierOne()
        {
            return categories.Where(one => one.ParentID == null).ToList();
        }

        public IEnumerable<ICategory> GetSubTiers(int parentCategory)
        {
            IList<ICategory> subCategories = new List<ICategory>();
            foreach(ICategory c in categories.Where(x => x.ParentID != null))
            {
                if(GetParentTiers(c.UniqueID).Object1 == parentCategory)
                {
                    subCategories.Add(c);
                }
            }
            return subCategories;
        }
    }
}
