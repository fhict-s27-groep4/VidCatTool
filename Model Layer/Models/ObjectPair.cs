using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Models
{
    public class ObjectPair<T1, T2> : IObjectPair<T1, T2>
    {
        public T1 Object1
        {
            get;
            set;
        }

        public T2 Object2
        {
            get;
            set;
        }
    }
}
