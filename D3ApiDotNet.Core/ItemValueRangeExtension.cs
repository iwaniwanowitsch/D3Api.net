using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core
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

        public static double GetValue(this ItemValueRange range)
        {
            return range.MinMaxEquals() ? range.Min : range.MinMaxAvg();
        }
    }
}
