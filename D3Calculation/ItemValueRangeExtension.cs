using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects.Item;

namespace D3Calculation
{
    static class ItemValueRangeExtension
    {
        private const double Tolerance = 0.0001;

        public static bool MinMaxEquals(this ItemValueRange range)
        {
            return Math.Abs(range.Min - range.Max) < Tolerance;
        }

        public static double MinMaxAvg(this ItemValueRange range)
        {
            return (range.Min + range.Max)/2;
        }

        public static double MinMax(this ItemValueRange range)
        {
            return range.MinMaxEquals() ? range.Min : range.MinMaxAvg();
        }
    }
}
