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
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating();
            rating1.setAll(5, 5, 4, 4, 4);
            Rating rating2 = new Rating();
            rating2.setAll(6, 5, 4, 4, 4);
            Rating rating3 = new Rating();
            rating3.setAll(7, 5, 4, 4, 4);
            Rating rating4 = new Rating();
            rating4.setAll(4, 5, 4, 4, 4);
            Rating rating5 = new Rating();
            rating5.setAll(5, 5, 4, 4, 4);
            Rating rating6 = new Rating();
            rating6.setAll(5, 5, 4, 4, 4);
            Rating rating7 = new Rating();
            rating7.setAll(6, 5, 4, 4, 4);
            Rating rating8 = new Rating();
            rating8.setAll(5, 5, 4, 4, 4);
            Rating rating9 = new Rating();
            rating9.setAll(5, 5, 4, 4, 4);
            Rating rating10 = new Rating();
            rating10.setAll(5, 5, 1, 1, 1);

            //act
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
            ratalgo.DivergentRatings += Ratalgo_DivergentRatings;
            ratalgo.FindDivergents(test);

            //assert
            Assert.True(rating10.PADIsDivergent);
        }

        private void Ratalgo_DivergentRatings(object sender, DivergentRatings e)
        {

        }

        [Fact]
        public void CheckAllOke()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating();
            rating1.setAll(5, 5, 4, 4, 4);
            Rating rating2 = new Rating();
            rating2.setAll(6, 5, 4, 4, 4);
            Rating rating3 = new Rating();
            rating3.setAll(7, 5, 4, 4, 4);
            Rating rating4 = new Rating();
            rating4.setAll(4, 5, 4, 4, 4);
            Rating rating5 = new Rating();
            rating5.setAll(5, 5, 4, 4, 4);

            //act
            test.Add(rating1);
            test.Add(rating2);
            test.Add(rating3);
            test.Add(rating4);
            test.Add(rating5);
            ratalgo.DivergentRatings += Ratalgo_DivergentRatings;
            ratalgo.FindDivergents(test);

            //assert
            Assert.False(rating1.PADIsDivergent);
            Assert.False(rating2.PADIsDivergent);
            Assert.False(rating3.PADIsDivergent);
            Assert.False(rating4.PADIsDivergent);
            Assert.False(rating5.PADIsDivergent);
        }
        [Fact]
        public void NoServiceDone()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating();
            rating1.setAll(5, 5, 4, 4, 4);
            Rating rating2 = new Rating();
            rating2.setAll(6, 5, 4, 4, 4);
            Rating rating4 = new Rating();
            rating4.setAll(4, 5, 4, 4, 4);
            Rating rating5 = new Rating();
            rating5.setAll(5, 5, 4, 4, 4);

            //act
            test.Add(rating1);
            test.Add(rating2);
            test.Add(rating4);
            test.Add(rating5);
            Action act = () => ratalgo.FindDivergents(test);

            //assert
            Assert.Throws<System.Exception>(act);
        }

        [Fact]
        public void NotEnoughRatings()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating();
            rating1.setAll(5, 5, 5, 5, 5);
            Rating rating2 = new Rating();
            rating2.setAll(6, 5, 1, 1, 1);

            //act
            test.Add(rating1);
            test.Add(rating2);
            ratalgo.FindDivergents(test);

            //assert
            Assert.False(rating1.PADIsDivergent);

        }
        [Fact]
        public void NotEnoughCat()
        {
            //arrange
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
            rating6.setAll(5, 5, 4, 4, 4);
            Rating rating7 = new Rating();
            rating7.setAll(5, 5, 4, 4, 4);
            Rating rating8 = new Rating();
            rating8.setAll(5, 5, 4, 4, 4);
            Rating rating9 = new Rating();
            rating9.setAll(5, 5, 4, 4, 4);
            Rating rating10 = new Rating();
            rating10.setAll(5, 5, 1, 1, 1);

            //act
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

            //assert
            Assert.False(rating1.IABIsDivergent);
            Assert.False(rating2.IABIsDivergent);
            Assert.False(rating3.IABIsDivergent);
            Assert.False(rating4.IABIsDivergent);
            Assert.False(rating5.IABIsDivergent);
        }
        [Fact]
        public void AlotofCategories()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating();
            rating1.setAll(1, 2, 4, 4, 4);
            Rating rating2 = new Rating();
            rating2.setAll(3, 4, 4, 4, 4);
            Rating rating3 = new Rating();
            rating3.setAll(5, 6, 4, 4, 4);
            Rating rating4 = new Rating();
            rating4.setAll(7, 8, 4, 4, 4);
            Rating rating5 = new Rating();
            rating5.setAll(9, 10, 4, 4, 4);
            Rating rating6 = new Rating();
            rating6.setAll(11, 12, 4, 4, 4);
            Rating rating7 = new Rating();
            rating7.setAll(13, 14, 4, 4, 4);
            Rating rating8 = new Rating();
            rating8.setAll(15, 16, 4, 4, 4);
            Rating rating9 = new Rating();
            rating9.setAll(17, 18, 4, 4, 4);
            Rating rating10 = new Rating();
            rating10.setAll(19, 20, 1, 1, 1);

            //act
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

            //assert
            ratalgo.FindDivergents(test);
        }
    }
}
