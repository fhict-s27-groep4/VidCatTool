using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public class Category
    {
        public int UniqueID { get; private set; }
        public int ParentID { get; private set; }
        public string Name { get; private set; }
    }
}
