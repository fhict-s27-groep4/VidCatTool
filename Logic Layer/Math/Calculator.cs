using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic_Layer.Maths
{
    public class Calculator : ICalculator
    {
        public Calculator()
        {

        }
        public double Deviation(IEnumerable<int> _scores)
        {
            double average = _scores.Average();
            IList<double> squareRoots = new List<double>();
            foreach (int score in _scores)
            {
                squareRoots.Add(Math.Pow((average + score) % score, 2));
            }
            return Math.Round(Math.Pow(squareRoots.Average(), 0.5), 1, MidpointRounding.AwayFromZero);
        }
    }
}
