using Logic_Layer;
using Logic_Layer.CategoryReverser;
using Model_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.LogicLayer.CategoryReverser
{
    public class CategoryReverserTest
    {
        private readonly CategoryManager category;
        public CategoryReverserTest()
        {
            //arrange
            List<Category> categories = new List<Category>();
            Category category1 = new Category();
            Category category2 = new Category();
            Category category3 = new Category();
            Category category4 = new Category();
            Category category5 = new Category();
            Category category6 = new Category();
            Category category7 = new Category();
            Category category8 = new Category();
            Category category9 = new Category();
            Category category10 = new Category();
            Category category11 = new Category();
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

            category5.ParentID = 2;
            category5.UniqueID = 5;
            category5.Name = "Boeing 747";

            category6.ParentID = 2;
            category6.UniqueID = 6;
            category6.Name = "Airbus A380-800F";

            category7.ParentID = 3;
            category7.UniqueID = 7;
            category7.Name = "Twinmotor";

            category8.ParentID = 3;
            category8.UniqueID = 8;
            category8.Name = "Small";

            category9.ParentID = 4;
            category9.UniqueID = 9;
            category9.Name = "V7";

            category10.ParentID = 4;
            category10.UniqueID = 10;
            category10.Name = "Medium";

            category11.ParentID = 5;
            category11.UniqueID = 11;
            category11.Name = "Boeing JetEngine";

            //act
            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);
            categories.Add(category5);
            categories.Add(category6);
            categories.Add(category7);
            categories.Add(category8);
            categories.Add(category9);
            categories.Add(category10);
            categories.Add(category11);

            category = new CategoryManager(categories);
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
        [Fact]
        public void GetSubTiersWithParentID()
        {
            List<Category> test = new List<Category>();
            List<ICategory> shit = category.GetSubTiers(2).ToList();
            foreach(Category cat in shit)
            {
                test.Add(cat);
            }
            Assert.Equal(3, test.Count);
        }
        [Fact]
        public void GetAllParentIDs()
        {
            List<Category> test = new List<Category>();
            List<ICategory> fill = category.GetAllTierOne().ToList();
            foreach(Category cat in fill)
            {
                test.Add(cat);
            }
            Assert.Equal(2, test.Count);        
        }
    }
}
