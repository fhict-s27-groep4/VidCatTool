using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogicLibrary.AlgoritmRatings
{
    public class RatingAlgoritm
    {
        private double iabToleranceTier1 = 0.85;
        private double iabToleranceTier2 = 0.75;
        private double biggestPercentIAB = 0.9;
        private double padTolerance = 1.5;
        private int maximumRatings = 80;
        public event EventHandler<DivergentRatings> DivergentRatings;

        public RatingAlgoritm()
        {

        }

        private IList<IObjectPair<int, int>> CatagoryInList(IList<IObjectPair<int, int>> _categoryList, int _categoryID)
        {
            for (int i = 0; i < _categoryList.Count; i++)
            {
                if (_categoryList[i].Object1 == _categoryID)
                {
                    _categoryList[i].Object2 += 1;
                }
            }
            return _categoryList;
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

        private IEnumerable<int> BiggestCategories(IEnumerable<IObjectPair<int, int>> _countCategories, int _count)
        {
            int currCount = _countCategories.Max(x => x.Object2);
            while (_countCategories.Where(x => x.Object2 >= currCount).Sum(x => x.Object2) > biggestPercentIAB * _count)
            {
                currCount--;
            }
            return _countCategories.Where(x => x.Object2 > currCount).Select(x => x.Object1);
        }

        protected virtual void OnDivergentRatings(IEnumerable<IRating> _ratings)
        {
            if (DivergentRatings == null)
            {
                throw new Exception();
            }
            DivergentRatings(this, new DivergentRatings(_ratings));
        }

        public void FindDivergents(IEnumerable<IRating> _ratings)
        {
            IList<IObjectPair<int, int>> countCatagorie1 = new List<IObjectPair<int, int>>();
            IList<IObjectPair<int, int>> countCatagorie2 = new List<IObjectPair<int, int>>();
            int count = 0;
            int pleassure = 0;
            int dominance = 0;
            int arrousel = 0;
            foreach (IRating rating in _ratings)
            {//generates count, total PAD, Counts catagories
                count++;
                countCatagorie1 = CatagoryInList(countCatagorie1, rating.Category1);
                countCatagorie2 = CatagoryInList(countCatagorie2, rating.Category2);
                pleassure += rating.Pleasure;
                dominance += rating.Dominance;
                arrousel += rating.Arrousel;
            }
            if (count <= maximumRatings)
            {//prevents video from getting more ratings
                if (count <= 3)
                {// video's with less tha 3 can't be checked
                    return;
                }
                if (!CatagoryBigEnough(countCatagorie1, iabToleranceTier1 * count) || !CatagoryBigEnough(countCatagorie1, iabToleranceTier2 * count))
                {//video's that don't have polarized category ratings can be finished early
                    return;
                }
            }
            IEnumerable<int> biggestCatagories = BiggestCategories(countCatagorie2, count);
            double averageP = pleassure / count;
            double averageA = arrousel / count;
            double averageD = dominance / count;
            foreach (IRating rating in _ratings)
            {//2 of 3 divergent pads>>>pad is divergent, tier2 is not in the list with biggest catagories>>>iabdivergent
                int divergentCount = 0;
                if ((rating.Pleasure + averageP) % averageP > padTolerance)
                {
                    divergentCount++;
                }
                if ((rating.Arrousel + averageA) % averageA > padTolerance)
                {
                    divergentCount++;
                }
                if ((rating.Dominance + averageD) % averageD > padTolerance)
                {
                    divergentCount++;
                }
                if (divergentCount >= 2)
                {
                    rating.PADIsDivergent = true;
                }
                if (!biggestCatagories.Contains(rating.Category2))
                {
                    rating.IABIsDivergent = true;
                }
            }
            IList<IRating> divergentRatings = new List<IRating>();
            foreach (IRating rating in _ratings)
            {
                if (rating.IABIsDivergent || rating.PADIsDivergent)
                {
                    divergentRatings.Add(rating);
                }
            }
            if (divergentRatings != null)
            {//outputs only the ratings where something is divergent
                OnDivergentRatings(divergentRatings);
            }
        }
    }
}
