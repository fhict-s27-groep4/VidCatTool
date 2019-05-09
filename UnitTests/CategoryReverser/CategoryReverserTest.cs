using Logic_Layer;
using Logic_Layer.CategoryReverser;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.CategoryReverser
{
    public class CategoryReverserTest
    {
        CategroyReverser category;
        public CategoryReverserTest()
        {
            //arrange
            List<Category> categories = new List<Category>();
            Category category1 = new Category();
            Category category2 = new Category();
            Category category3 = new Category();
            Category category4 = new Category();
            category1.ParentID = null;
            category1.UniqueID = 1;
            category1.Name = "Auto";

            category2.ParentID = null;
            category2.UniqueID = 2;
            category2.Name = "Vliegtuig";

            category3.ParentID = 1;
            category3.UniqueID = 3;
            category3.Name = "Bently";

            category4.ParentID = 1;
            category4.UniqueID = 4;
            category4.Name = "Honda";

            //act
            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);

            category = new CategroyReverser(categories);
        }

        [Fact]
        public void GetParentIDHonda()
        {
            IObjectPair<int,int> parentID = category.GetParentTiers(4);
            Assert.Equal(1, parentID.Object1);
            Assert.Equal(4, parentID.Object2);
        }

        [Fact]
        public void GetParentIDBently()
        {
            IObjectPair<int, int> parentID = category.GetParentTiers(3);
            Assert.Equal(1, parentID.Object1);
            Assert.Equal(3, parentID.Object2);
        }
    }
}
