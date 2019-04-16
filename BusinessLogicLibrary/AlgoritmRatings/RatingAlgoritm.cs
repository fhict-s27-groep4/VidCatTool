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
        public event EventHandler<DivergentRatings> DivergentRatings;

        public RatingAlgoritm()
        {

        }

        private IList<IObjectPair<int, int>> CatagorieInList(IList<IObjectPair<int, int>> _catagoryList, int _catagoryID)
        {
            for (int i = 0; i < _catagoryList.Count; i++)
            {
                if (_catagoryList[i].Object1 == _catagoryID)
                {
                    _catagoryList[i].Object2 += 1;
                }
            }
            return _catagoryList;
        }

        private bool CatagorieBigEnough(IList<IObjectPair<int, int>> _countCatagorie, double _passAmount)
        {
            foreach (IObjectPair<int, int> pair in _countCatagorie)
            {
                if (pair.Object2 >= _passAmount)
                {
                    return true;
                }
            }
            return false;
        }

        private IEnumerable<int> BiggestCategories(IEnumerable<IObjectPair<int, int>> _countCatagories, int _count)
        {
            int currCount = _countCatagories.Max(x => x.Object2);
            while (_countCatagories.Where(x => x.Object2 >= currCount).Sum(x => x.Object2) > biggestPercentIAB * _count)
            {
                currCount--;
            }
            return _countCatagories.Where(x => x.Object2 > currCount).Select(x => x.Object1);
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
            {
                count++;
                countCatagorie1 = CatagorieInList(countCatagorie1, rating.Catagory1);
                countCatagorie2 = CatagorieInList(countCatagorie2, rating.Catagory2);
                pleassure += rating.Pleasure;
                dominance += rating.Dominance;
                arrousel += rating.Arrousel;
            }
            if (count <= 3)
            {
                return;
            }
            if (!CatagorieBigEnough(countCatagorie1, iabToleranceTier1 * count) || !CatagorieBigEnough(countCatagorie1, iabToleranceTier2 * count))
            {
                return;
            }
            IEnumerable<int> biggestCatagories = BiggestCategories(countCatagorie2, count);
            double averageP = pleassure / count;
            double averageA = arrousel / count;
            double averageD = dominance / count;
            foreach (IRating rating in _ratings)
            {
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
                if (!biggestCatagories.Contains(rating.Catagory2))
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
            {
                OnDivergentRatings(divergentRatings);
            }
        }
    }
}
