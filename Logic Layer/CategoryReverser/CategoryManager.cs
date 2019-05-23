using Model_Layer.Interface;
using Model_Layer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic_Layer.CategoryReverser
{
    public class CategoryManager : ICategoryManager
    {
        private IEnumerable<ICategory> categories;
        public CategoryManager(IAllCategories _categories)
        {
            categories = _categories.Categories;
        }

        public bool IsTier(int tier, int catID)
        {
            int tierCount = 1;
            ICategory currCat = GetCategory(catID);
            while(currCat.ParentID != null)
            {
                currCat = GetCategory((int)currCat.ParentID);
                tierCount++;
            }
            return tier == tierCount;
        }

        public ICategory GetCategory(int catID)
        {
            return categories.Where(x => x.UniqueID == catID).First();
        }

        public IObjectPair<int, int> GetParentTiers(int _categoryID)
        {
            IObjectPair<int, int> parentTiers = new ObjectPair<int, int>();
            ICategory current = categories.Where(x => x.UniqueID == _categoryID).First();
            while(current.ParentID != null)
            {
                parentTiers.Object1 = (int)current.ParentID;
                parentTiers.Object2 = current.UniqueID;
                current = GetCategory(parentTiers.Object1);
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
