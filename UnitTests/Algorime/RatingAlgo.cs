using System;
using System.Collections.Generic;
using Xunit;
using System.Text;
using BusinessLogicLibrary.AlgoritmRatings;
using BusinessLogicLibrary;

namespace UnitTests.Algorime
{
    public class RatingAlgo
    {
        private readonly RatingAlgoritm ratalgo;

        public RatingAlgo()
        {
            ratalgo = new RatingAlgoritm();
        }

        [Fact]
        public void CheckDivergentRating()
        {
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating();
            rating1.setAll(5, 5, 4, 4, 4);
            Rating rating2 = new Rating();
            rating2.setAll(5, 5, 4, 4, 4);
            Rating rating3 = new Rating();
            rating3.setAll(5, 5, 4, 4, 4);
            Rating rating4 = new Rating();
            rating4.setAll(5, 5, 4, 4, 4);
            Rating rating5 = new Rating();
            rating5.setAll(5, 5, 4, 4, 4);
            Rating rating6 = new Rating();
            rating3.setAll(5, 5, 4, 4, 4);
            Rating rating7 = new Rating();
            rating3.setAll(5, 5, 4, 4, 4);
            Rating rating8 = new Rating();
            rating3.setAll(5, 5, 4, 4, 4);
            Rating rating9 = new Rating();
            rating3.setAll(5, 5, 4, 4, 4);
            Rating rating10 = new Rating();
            rating10.setAll(5, 5, 1, 1, 1);
            test.Add(rating1);
            test.Add(rating2);
            test.Add(rating3);
            test.Add(rating4);
            test.Add(rating5);
            test.Add(rating6);
            test.Add(rating7);
            test.Add(rating8);
            test.Add(rating9);
            test.Add(rating10);
            ratalgo.FindDivergents(test);
            Assert.True(rating10.PADIsDivergent);
        }
    }
}
