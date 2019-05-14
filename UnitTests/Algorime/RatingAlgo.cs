using System;
using System.Collections.Generic;
using Xunit;
using System.Text;
using Logic_Layer.AlgoritmRatings;
using Model_Layer.Models;
using Model_Layer.Interface;

namespace UnitTests.Algorime
{
    public class RatingAlgo
    {
        private RatingAlgoritm ratalgo;
        List<IRating> CheckCorrect;

        public RatingAlgo()
        {
            List<Category> categories = new List<Category>();
            Category category1 = new Category();
            Category category2 = new Category();
            Category category3 = new Category();
            Category category4 = new Category();
            Category category5 = new Category();
            Category category6 = new Category();
            Category category7 = new Category();
            Category category8 = new Category();
            Category category9 = new Category();
            Category category10 = new Category();
            Category category11 = new Category();
            category1.ParentID = null;
            category1.UniqueID = 1;
            category1.Name = "Auto";

            category2.ParentID = null;
            category2.UniqueID = 2;
            category2.Name = "Vliegtuig";

            category3.ParentID = 1;
            category3.UniqueID = 3;
            category3.Name = "Bently";

            category4.ParentID = 1;
            category4.UniqueID = 4;
            category4.Name = "Honda";

            category5.ParentID = 2;
            category5.UniqueID = 5;
            category5.Name = "Boeing 747";

            category6.ParentID = 2;
            category6.UniqueID = 6;
            category6.Name = "Airbus A380-800F";

            category7.ParentID = 3;
            category7.UniqueID = 7;
            category7.Name = "Twinmotor";

            category8.ParentID = 3;
            category8.UniqueID = 8;
            category8.Name = "Small";

            category9.ParentID = 4;
            category9.UniqueID = 9;
            category9.Name = "V7";

            category10.ParentID = 4;
            category10.UniqueID = 10;
            category10.Name = "Medium";

            category11.ParentID = 5;
            category11.UniqueID = 11;
            category11.Name = "Boeing JetEngine";

            //act
            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);
            categories.Add(category5);
            categories.Add(category6);
            categories.Add(category7);
            categories.Add(category8);
            categories.Add(category9);
            categories.Add(category10);
            categories.Add(category11);
            ratalgo = new RatingAlgoritm(new Logic_Layer.CategoryReverser.CategoryManager(categories));
        }

        [Fact]
        public void CheckDivergentRating()
        {
            //arrange
            List<IRating> test = new List<IRating>();

            Rating rating1 = new Rating { CategoryID = 3, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating2 = new Rating { CategoryID = 4, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating3 = new Rating { CategoryID = 5, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating4 = new Rating { CategoryID = 2, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating5 = new Rating { CategoryID = 4, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating6 = new Rating { CategoryID = 1, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating7 = new Rating { CategoryID = 3, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating8 = new Rating { CategoryID = 3, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating9 = new Rating { CategoryID = 3, DominanceIndex = 4, PleasureIndex = 4, ArrousalIndex = 4 };
            Rating rating10 = new Rating { CategoryID = 3, DominanceIndex = 1, PleasureIndex = 1, ArrousalIndex = 1 };

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
            Assert.Throws<System.NotImplementedException>(act);
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
        [Fact]
        public void CheckEventWorkingCorrect()
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
            Rating rating11 = new Rating { CategoryID = 5, DominanceIndex = 1, PleasureIndex = 1, ArrousalIndex = 1 };
            Rating rating12 = new Rating { CategoryID = 5, DominanceIndex = 1, PleasureIndex = 1, ArrousalIndex = 1 };
            Rating rating13 = new Rating { CategoryID = 3, DominanceIndex = 1, PleasureIndex = 1, ArrousalIndex = 1 };

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
            test.Add(rating11);
            test.Add(rating12);
            test.Add(rating13);
            ratalgo.DivergentRatings += Ratalgo_DivergentRatings2;
            string vidID = ratalgo.FindDivergents(test);
            int x = 0;

            //assert
            Assert.Equal(3, CheckCorrect.Count);
        }

        private void Ratalgo_DivergentRatings2(object sender, DivergentRatings e)
        {
            CheckCorrect = new List<IRating>();
            foreach (Rating rating in e.Ratings)
            {
                CheckCorrect.Add(rating);
            }
        }
    }
}
