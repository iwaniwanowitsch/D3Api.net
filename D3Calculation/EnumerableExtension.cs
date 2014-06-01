using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Calculation
{
    public static class EnumerableExtension
    {
        public static double Product(this IEnumerable<double> enumerable)
        {
            return enumerable.Aggregate(1.0, (accumulator, current) => accumulator * current);
        }
    }
}
