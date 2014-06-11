using System.Collections.Generic;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public interface IAttributeFetcher
    {
        double GetBonusDamage(IEnumerable<ItemAttributes> attributes);

        double GetBonusDamage(IEnumerable<Item> items);
    }
}
