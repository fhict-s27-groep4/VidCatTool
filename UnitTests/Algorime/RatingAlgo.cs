using System;
using System.Collections.Generic;
using Xunit;
using System.Text;
using Logic_Layer.AlgoritmRatings;
using Model_Layer.Models;

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
            ////arrange
            List<IRating> test = new List<IRating>();

            Rating rating1 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 8, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating3 = new Rating { CategoryID = 6, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating4 = new Rating { CategoryID = 7, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating5 = new Rating { CategoryID = 4, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating6 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating7 = new Rating { CategoryID = 6, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating8 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating9 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating10 = new Rating { CategoryID = 5, DominanceIndex = 1, PleasureIndex = 1, ArrousalIndex = 1 };

            //act
            test.Add(rating1 as IRating);
            test.Add(rating2 as IRating);
            test.Add(rating3 as IRating);
            test.Add(rating4 as IRating);
            test.Add(rating5 as IRating);
            test.Add(rating6 as IRating);
            test.Add(rating7 as IRating);
            test.Add(rating8 as IRating);
            test.Add(rating9 as IRating);
            test.Add(rating10 as IRating);
            ratalgo.DivergentRatings += Ratalgo_DivergentRatings;
            ratalgo.FindDivergents(test);

            //assert
            Assert.True(rating10.IsPADDivergent);
        }

        private void Ratalgo_DivergentRatings(object sender, DivergentRatings e)
        {

        }

        [Fact]
        public void CheckAllOke()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating3 = new Rating { CategoryID = 6, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating4 = new Rating { CategoryID = 7, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating5 = new Rating { CategoryID = 4, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };

            //act
            test.Add(rating1 as IRating);
            test.Add(rating2 as IRating);
            test.Add(rating3 as IRating);
            test.Add(rating4 as IRating);
            test.Add(rating5 as IRating);
            ratalgo.DivergentRatings += Ratalgo_DivergentRatings;
            ratalgo.FindDivergents(test);

            //assert
            Assert.False(rating1.IsPADDivergent);
            Assert.False(rating2.IsPADDivergent);
            Assert.False(rating3.IsPADDivergent);
            Assert.False(rating4.IsPADDivergent);
            Assert.False(rating5.IsPADDivergent);
        }
        [Fact]
        public void NoServiceDone()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating3 = new Rating { CategoryID = 6, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating4 = new Rating { CategoryID = 7, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating5 = new Rating { CategoryID = 4, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };

            //act
            test.Add(rating1 as IRating);
            test.Add(rating2 as IRating);
            test.Add(rating3 as IRating);
            test.Add(rating4 as IRating);
            test.Add(rating5 as IRating);
            Action act = () => ratalgo.FindDivergents(test);

            //assert
            Assert.Throws<System.Exception>(act);
        }

        [Fact]
        public void NotEnoughRatings()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };

            //act
            test.Add(rating1 as IRating);
            test.Add(rating2 as IRating);
            ratalgo.FindDivergents(test);

            //assert
            Assert.False(rating1.IsPADDivergent);

        }
        [Fact]
        public void NotEnoughCat()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating3 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating4 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating5 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating6 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating7 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating8 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating9 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating10 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };

            //act
            test.Add(rating1 as IRating);
            test.Add(rating2 as IRating);
            test.Add(rating3 as IRating);
            test.Add(rating4 as IRating);
            test.Add(rating5 as IRating);
            test.Add(rating6 as IRating);
            test.Add(rating7 as IRating);
            test.Add(rating8 as IRating);
            test.Add(rating9 as IRating);
            test.Add(rating10 as IRating);
            ratalgo.FindDivergents(test);

            //assert
            Assert.False(rating1.IsIABDivergent);
            Assert.False(rating2.IsIABDivergent);
            Assert.False(rating3.IsIABDivergent);
            Assert.False(rating4.IsIABDivergent);
            Assert.False(rating5.IsIABDivergent);
        }
        [Fact]
        public void AlotofCategories()
        {
            //arrange
            List<IRating> test = new List<IRating>();
            Rating rating1 = new Rating { CategoryID = 1, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 2, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating3 = new Rating { CategoryID = 3, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating4 = new Rating { CategoryID = 4, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating5 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating6 = new Rating { CategoryID = 6, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating7 = new Rating { CategoryID = 7, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating8 = new Rating { CategoryID = 8, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating9 = new Rating { CategoryID = 9, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating10 = new Rating { CategoryID = 10, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };

            //act
            test.Add(rating1 as IRating);
            test.Add(rating2 as IRating);
            test.Add(rating3 as IRating);
            test.Add(rating4 as IRating);
            test.Add(rating5 as IRating);
            test.Add(rating6 as IRating);
            test.Add(rating7 as IRating);
            test.Add(rating8 as IRating);
            test.Add(rating9 as IRating);
            test.Add(rating10 as IRating);
            ratalgo.DivergentRatings += Ratalgo_DivergentRatings;
            ratalgo.FindDivergents(test);

            Assert.True(rating1.IsIABDivergent);
            Assert.True(rating2.IsIABDivergent);
            Assert.True(rating3.IsIABDivergent);
            Assert.True(rating4.IsIABDivergent);
            Assert.True(rating5.IsIABDivergent);
        }
    }
}
