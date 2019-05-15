using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic_Layer.AlgoritmRatings
{
    public class RatingAlgoritm
    {
        private readonly double iabToleranceTier1 = 0.85;
        private readonly double iabToleranceTier2 = 0.75;
        private readonly double biggestPercentIAB = 0.9;
        private readonly double padTolerance = 0.7;
        private readonly int maximumRatings = 80;
        private readonly CategoryReverser.CategoryManager categoryReverser;
        public event EventHandler<DivergentRatings> DivergentRatings;

        public RatingAlgoritm(CategoryReverser.CategoryManager _categroyReverser)
        {
            categoryReverser = _categroyReverser;
        }

        private IList<IObjectPair<int, int>> CatagoryInList(IList<IObjectPair<int, int>> _categoryList, int _categoryID)
        {
            IList<IObjectPair<int, int>> categoryList = new List<IObjectPair<int, int>>();
            foreach (IObjectPair<int, int> pair in _categoryList)
            {
                categoryList.Add(pair);
            }
            for (int i = 0; i < _categoryList.Count; i++)
            {
                if (categoryList[i].Object1 == _categoryID)
                {
                    categoryList[i].Object2 += 1;
                    return categoryList;
                }

            }
            categoryList.Add(new ObjectPair<int, int>() { Object1 = _categoryID, Object2 = 1 });
            return categoryList;
        }

        private bool CatagoryBigEnough(IList<IObjectPair<int, int>> _countCategorie, double _passAmount)
        {
            foreach (IObjectPair<int, int> pair in _countCategorie)
            {
                if (pair.Object2 >= _passAmount)
                {
                    return true;
                }
            }
            return false;
        }

        private IEnumerable<int> BiggestCategories(IList<IObjectPair<int, int>> _countCategories, int _count)
        {
            IList<int> biggestCategories = new List<int>();
            int curCount = 0;
            while(curCount < biggestPercentIAB * _count)
            {
                IEnumerable<IObjectPair<int, int>> newBiggestCategories = _countCategories.Where(x => x.Object2 == _countCategories.Max(y => y.Object2)).ToList();
                foreach (IObjectPair<int, int> c in newBiggestCategories)
                {
                    curCount += c.Object2;
                    biggestCategories.Add(c.Object1);
                    _countCategories.Remove(c);
                }
            }
            return biggestCategories;
        }

        protected virtual void OnDivergentRatings(IEnumerable<IRating> _ratings)
        {
            if (DivergentRatings == null)
            {
                throw new NotImplementedException();
            }
            DivergentRatings(this, new DivergentRatings(_ratings));
        }

        public string FindDivergents(IEnumerable<IRating> _ratings)
        {
            IList<IObjectPair<int, int>> countCatagorie1 = new List<IObjectPair<int, int>>();
            IList<IObjectPair<int, int>> countCatagorie2 = new List<IObjectPair<int, int>>();
            int count = _ratings.Count();
            int pleassure = 0;
            int dominance = 0;
            int arrousel = 0;
            foreach (IRating rating in _ratings)
            {//generates count, total PAD, Counts catagories
                IObjectPair<int, int> categoryIDs = categoryReverser.GetParentTiers(rating.CategoryID);
                countCatagorie1 = CatagoryInList(countCatagorie1, categoryIDs.Object1);
                countCatagorie2 = CatagoryInList(countCatagorie2, categoryIDs.Object2);
                pleassure += rating.PleasureIndex;
                dominance += rating.DominanceIndex;
                arrousel += rating.ArrousalIndex;
            }
            if (count <= maximumRatings)
            {//prevents video from getting more ratings
                if (count <= 3)
                {// video's with less tha 3 can't be checked
                    return null;
                }
                if (!CatagoryBigEnough(countCatagorie1, iabToleranceTier1 * count) || !CatagoryBigEnough(countCatagorie2, iabToleranceTier2 * count))
                {//video's that don't have polarized category ratings can be finished early
                    return null;
                }
            }
            IEnumerable<int> biggestCatagories = BiggestCategories(countCatagorie2, count);
            double averageP = (double)pleassure / count;
            double averageA = (double)arrousel / count;
            double averageD = (double)dominance / count;
            foreach (IRating rating in _ratings)
            {//2 of 3 divergent pads>>>pad is divergent, tier2 is not in the list with biggest catagories>>>iabdivergent
                int divergentCount = 0;
                if ((rating.PleasureIndex + averageP) % averageP > padTolerance)
                {
                    divergentCount++;
                }
                if ((rating.ArrousalIndex + averageA) % averageA > padTolerance)
                {
                    divergentCount++;
                }
                if ((rating.DominanceIndex + averageD) % averageD > padTolerance)
                {
                    divergentCount++;
                }
                if (divergentCount >= 2)
                {
                    rating.IsPADDivergent = true;
                }
                if (!biggestCatagories.Contains(categoryReverser.GetParentTiers(rating.CategoryID).Object2))
                {
                    rating.IsIABDivergent = true;
                }
            }
            IList<IRating> divergentRatings = new List<IRating>();
            foreach (IRating rating in _ratings)
            {
                if (rating.IsIABDivergent || rating.IsPADDivergent)
                {
                    divergentRatings.Add(rating);
                }
            }
            if (divergentRatings.Count() > 0)
            {
                OnDivergentRatings(divergentRatings);
            }
            return _ratings.First().VideoIdentity;
        }
    }
}
