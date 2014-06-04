using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public interface IAttributeFetcher
    {
        double GetBonusDamage(IEnumerable<ItemAttributes> attributes);

        double GetBonusDamage(IEnumerable<Item> items);
    }
}
