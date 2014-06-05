using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class DamageFormulaFactory : IFormulaFactory
    {
        private readonly List<Item> _itemList;
        private readonly IAttributeFetcher _mainAttributeFetcher;

        public DamageFormulaFactory(List<Item> itemList, IAttributeFetcher mainAttributeFetcher)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (mainAttributeFetcher == null) throw new ArgumentNullException("mainAttributeFetcher");
            _itemList = itemList;
            _mainAttributeFetcher = mainAttributeFetcher;
        }

        public ITerm CreateFormula()
        {
            var weapons = _itemList.Where(o => o.AttacksPerSecond != null).ToList();

            var weaponsDps = new WeaponDpsFormulaFactory(_itemList, weapons, new MinDamageFetcher(),
                new DeltaDamageFetcher(), new MinWeaponDamageFetcher(), new DeltaWeaponDamageFetcher(),
                new ApsWeaponFetcher(), new ApsPercentWeaponFetcher(), new PercentWeaponDamageFetcher());

            return null;
        }
    }
}
