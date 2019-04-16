using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogicLibrary.AlgoritmRatings
{
    public class RatingAlgoritm
    {
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
            if (count < 3)
            {
                return;
            }
            if (!CatagorieBigEnough(countCatagorie1, 0.85 * count) || !CatagorieBigEnough(countCatagorie1, 0.75 * count))
            {
                return;
            }
            foreach()
        }
    }
}
