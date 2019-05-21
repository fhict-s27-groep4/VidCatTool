using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.CategoryReverser
{
    public interface IAllCategories
    {
        IEnumerable<ICategory> Categories { get; }
    }
}
