using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class WeaponDpsFormulaFactory : IFormulaFactory
    {
        private readonly List<Item> _itemList;
        private readonly List<Item> _weapons;
        private readonly MinDamageFetcher _minDamageFetcher;
        private readonly DeltaDamageFetcher _deltaDamageFetcher;
        private readonly MinWeaponDamageFetcher _minWeaponDamageFetcher;
        private readonly DeltaWeaponDamageFetcher _deltaWeaponDamageFetcher;
        private readonly ApsWeaponFetcher _apsWeaponFetcher;
        private readonly ApsPercentWeaponFetcher _apsPercentWeaponFetcher;
        private readonly PercentWeaponDamageFetcher _percentWeaponDamageFetcher;

        public WeaponDpsFormulaFactory(List<Item> itemList, List<Item> weapons, MinDamageFetcher minDamageFetcher, DeltaDamageFetcher deltaDamageFetcher, MinWeaponDamageFetcher minWeaponDamageFetcher, DeltaWeaponDamageFetcher deltaWeaponDamageFetcher, ApsWeaponFetcher apsWeaponFetcher, ApsPercentWeaponFetcher apsPercentWeaponFetcher, PercentWeaponDamageFetcher percentWeaponDamageFetcher)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (weapons == null) throw new ArgumentNullException("weapons");
            if (minDamageFetcher == null) throw new ArgumentNullException("minDamageFetcher");
            if (deltaDamageFetcher == null) throw new ArgumentNullException("deltaDamageFetcher");
            if (minWeaponDamageFetcher == null) throw new ArgumentNullException("minWeaponDamageFetcher");
            if (deltaWeaponDamageFetcher == null) throw new ArgumentNullException("deltaWeaponDamageFetcher");
            if (apsWeaponFetcher == null) throw new ArgumentNullException("apsWeaponFetcher");
            if (apsPercentWeaponFetcher == null) throw new ArgumentNullException("apsPercentWeaponFetcher");
            if (percentWeaponDamageFetcher == null) throw new ArgumentNullException("percentWeaponDamageFetcher");
            _itemList = itemList;
            _weapons = weapons;
            _minDamageFetcher = minDamageFetcher;
            _deltaDamageFetcher = deltaDamageFetcher;
            _minWeaponDamageFetcher = minWeaponDamageFetcher;
            _deltaWeaponDamageFetcher = deltaWeaponDamageFetcher;
            _apsWeaponFetcher = apsWeaponFetcher;
            _apsPercentWeaponFetcher = apsPercentWeaponFetcher;
            _percentWeaponDamageFetcher = percentWeaponDamageFetcher;
        }

        public ITerm CreateFormula()
        {
            var baseFactory = new BaseTermFactory();
            var sumFactory = new SumTermFactory();
            var productFactory = new ProductTermFactory();
            var divisionFactory = new DivisionTermFactory();
            var percentFactry = new PercentSumTermFactory();
            var averageFactory = new AverageTermFactory(sumFactory, productFactory, divisionFactory);

            var bonusDmgAvg =
                averageFactory.CreateFormulaTerm(new List<ITerm>
                {
                    sumFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        baseFactory.CreateAttributeTerm(_itemList, _minDamageFetcher),
                        baseFactory.CreateAttributeTerm(_itemList, _minDamageFetcher)
                    }),
                    baseFactory.CreateAttributeTerm(_itemList, _deltaDamageFetcher)
                });
            var weaponCount = _weapons.Count;

            var weaponDmgAvg =
                averageFactory.CreateFormulaTerm(new List<ITerm>
                {
                    sumFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        baseFactory.CreateAttributeTerm(_weapons, _minWeaponDamageFetcher),
                        baseFactory.CreateAttributeTerm(_weapons, _minWeaponDamageFetcher)
                    }),
                    baseFactory.CreateAttributeTerm(_weapons, _deltaWeaponDamageFetcher)
                });
            // one weapon
            if (weaponCount == 1)
            {
                var damageTerm =
                    sumFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        productFactory.CreateFormulaTerm(new List<ITerm>
                        {
                            percentFactry.CreateFormulaTerm(new List<ITerm>
                            {
                                baseFactory.CreateAttributeTerm(_weapons, _percentWeaponDamageFetcher)
                            }),
                            weaponDmgAvg
                        }),
                        bonusDmgAvg
                    });
                return
                    productFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        damageTerm,
                        baseFactory.CreateAttributeTerm(_weapons, _apsWeaponFetcher),
                        percentFactry.CreateFormulaTerm(new List<ITerm>
                        {
                            baseFactory.CreateAttributeTerm(_weapons, _apsPercentWeaponFetcher)
                        })
                    });
            }
                // two weapons
            else
            {
                weaponDmgAvg =
                    productFactory.CreateFormulaTerm(new List<ITerm> {weaponDmgAvg, baseFactory.CreateConstantTerm(0.5)});
                var damageTerm = 
                    sumFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        productFactory.CreateFormulaTerm(new List<ITerm>
                        {
                            percentFactry.CreateFormulaTerm(new List<ITerm>
                            {
                                baseFactory.CreateAttributeTerm(_weapons, _percentWeaponDamageFetcher)
                            }),
                            weaponDmgAvg
                        }),
                        bonusDmgAvg
                    });
                var atkSpd =
                    productFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        baseFactory.CreateConstantTerm(2),
                        baseFactory.CreateAttributeTerm(new List<Item> {_weapons[0]}, _apsWeaponFetcher),
                        baseFactory.CreateAttributeTerm(new List<Item> {_weapons[1]}, _apsWeaponFetcher),
                        divisionFactory.CreateFormulaTerm(new List<ITerm>
                        {
                            baseFactory.CreateAttributeTerm(_weapons, _apsWeaponFetcher)
                        })
                    });
                return
                    productFactory.CreateFormulaTerm(new List<ITerm>
                    {
                        damageTerm,
                        atkSpd,
                        percentFactry.CreateFormulaTerm(new List<ITerm>
                        {
                            baseFactory.CreateAttributeTerm(_weapons, _apsPercentWeaponFetcher)
                        })
                    });
            }
        }
    }
}