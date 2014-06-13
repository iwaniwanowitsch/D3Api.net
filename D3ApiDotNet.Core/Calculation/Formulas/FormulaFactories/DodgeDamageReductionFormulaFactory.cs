using System;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class DodgeDamageReductionFormulaFactory : AbstractFormulaFactory
    {
        private readonly AttributeFormulaFactory _dexterityFormulaFactory;
        private readonly double _heroLvl;

        public DodgeDamageReductionFormulaFactory(ElementalTermFactories factories, AttributeFormulaFactory dexterityFormulaFactory, double heroLvl) : base(factories)
        {
            if (dexterityFormulaFactory == null) throw new ArgumentNullException("dexterityFormulaFactory");
            _dexterityFormulaFactory = dexterityFormulaFactory;
            _heroLvl = heroLvl;
        }

        public override ITerm CreateFormula()
        {
            var factor = _heroLvl <= 60 ? 0.0097 : 0.0046;
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(1),
                Factories.SubstractionFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(
                        _dexterityFormulaFactory.CreateFormula(),
                        Factories.BaseFactory.CreateConstantTerm(factor),
                        Factories.BaseFactory.CreateConstantTerm(1.0/100)
                        )
                    )
                );
        }
    }
}