using System.Collections.Generic;

namespace Logic_Layer.Maths
{
    public interface ICalculator
    {
        double Deviation(IEnumerable<int> _scores);
    }
}