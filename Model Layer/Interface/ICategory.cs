using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface ICategory
    {
        int UniqueID { get; set; }
        int ParentID { get; set; }
        string Name { get; set; }
    }
}
