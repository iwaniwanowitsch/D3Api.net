using System;

namespace D3Calculation.Formulas
{
    public class ResistanceDamageReductionFormulaFactory : AbstractFormulaFactory
    {
        private readonly ResistanceFormulaFactory _resistanceFormulaFactory;
        private readonly double _heroLvl;

        public ResistanceDamageReductionFormulaFactory(ElementalTermFactories factories, ResistanceFormulaFactory resistanceFormulaFactory, double heroLvl)
            : base(factories)
        {
            if (resistanceFormulaFactory == null) throw new ArgumentNullException("resistanceFormulaFactory");
            _resistanceFormulaFactory = resistanceFormulaFactory;
            _heroLvl = heroLvl;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(1),
                Factories.SubstractionFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(_resistanceFormulaFactory.CreateFormula(),
                        Factories.DivisionFactory.CreateFormulaTerm(
                            Factories.SumFactory.CreateFormulaTerm(
                                Factories.BaseFactory.CreateConstantTerm(_heroLvl * 5),
                                _resistanceFormulaFactory.CreateFormula())))));
        }
    }
}