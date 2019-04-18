using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary.AlgoritmRatings
{
    public class ObjectPair<T1, T2> : IObjectPair<T1, T2>
    {
        public T1 Object1
        {
            get { return Object1; }
            set { Object1 = value; }
        }

        public T2 Object2
        {
            get { return Object2; }
            set { Object2 = value; }
        }
    }
}
