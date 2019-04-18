using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary.AlgoritmRatings
{
    class TestClass_deleted_soon_
    {
        public TestClass_deleted_soon_()
        {
            List<IRating> test = new List<IRating>();
            //(1, 2, false, 4, 3, 4, false, test)
            Rating rating1 = new Rating();
            rating1.setAll(5, 5, 4, 4, 4);
            Rating rating2 = new Rating();
            rating2.setAll(5, 5, 4, 4, 4);
            Rating rating3 = new Rating();
            rating3.setAll(5, 5, 4, 4, 4);
            Rating rating4 = new Rating();
            rating4.setAll(5, 5, 1, 1, 1);
            test.Add(rating1);
            test.Add(rating2);
            test.Add(rating3);
            test.Add(rating4);
            RatingAlgoritm ratalgo = new RatingAlgoritm();
            ratalgo.FindDivergents(test);
            
        }
        
    }
}
