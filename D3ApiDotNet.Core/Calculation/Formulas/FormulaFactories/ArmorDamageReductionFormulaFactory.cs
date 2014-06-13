using System;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class ArmorDamageReductionFormulaFactory : AbstractFormulaFactory
    {
        private readonly ArmorFormulaFactory _armorFormulaFactory;
        private readonly double _heroLvl;

        public ArmorDamageReductionFormulaFactory(ElementalTermFactories factories, ArmorFormulaFactory armorFormulaFactory, double heroLvl) : base(factories)
        {
            if (armorFormulaFactory == null) throw new ArgumentNullException("armorFormulaFactory");
            _armorFormulaFactory = armorFormulaFactory;
            _heroLvl = heroLvl;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(1),
                Factories.SubstractionFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(_armorFormulaFactory.CreateFormula(),
                        Factories.DivisionFactory.CreateFormulaTerm(
                            Factories.SumFactory.CreateFormulaTerm(
                                Factories.BaseFactory.CreateConstantTerm(_heroLvl*50),
                                _armorFormulaFactory.CreateFormula())))));
        }
    }
}