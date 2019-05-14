using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ModelTests
{
    public class CatagoryClassTest
    {
        Category catagory;
        public CatagoryClassTest()
        {
            catagory = new Category();
        }
        [Fact]
        public void CheckGetSetCategory()
        {
            //arange
            catagory.UniqueID = 1;
            catagory.ParentID = 5;
            catagory.Name = "Auto";

            //assert
            Assert.Equal(1, catagory.UniqueID);
            Assert.Equal(5, catagory.ParentID);
            Assert.Equal("Auto", catagory.Name);
        }
        [Fact]
        public void CheckGetSetNotEqualCategory()
        {
            //arange
            catagory.UniqueID = 1;
            catagory.ParentID = 5;
            catagory.Name = "Auto";

            //assert
            Assert.NotEqual(2, catagory.UniqueID);
            Assert.NotEqual(7, catagory.ParentID);
            Assert.NotEqual("Autos", catagory.Name);
        }
    }
}
