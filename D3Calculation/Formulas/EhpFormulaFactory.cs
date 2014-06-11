using System;

namespace D3Calculation.Formulas
{
    public class EhpFormulaFactory : AbstractFormulaFactory
    {
        private readonly MaxLifeFormulaFactory _maxLifeFormulaFactory;
        private readonly ArmorDamageReductionFormulaFactory _armorDamageReductionFormulaFactory;
        private readonly ResistanceDamageReductionFormulaFactory _resistanceDamageReductionFormulaFactory;
        private readonly DodgeDamageReductionFormulaFactory _dodgeDamageReductionFormulaFactory;
        private readonly OtherDamageReductionFormulaFactory _otherDamageReductionFormulaFactory;

        public EhpFormulaFactory(ElementalTermFactories factories, MaxLifeFormulaFactory maxLifeFormulaFactory, ArmorDamageReductionFormulaFactory armorDamageReductionFormulaFactory, ResistanceDamageReductionFormulaFactory resistanceDamageReductionFormulaFactory, DodgeDamageReductionFormulaFactory dodgeDamageReductionFormulaFactory, OtherDamageReductionFormulaFactory otherDamageReductionFormulaFactory) : base(factories)
        {
            if (maxLifeFormulaFactory == null) throw new ArgumentNullException("maxLifeFormulaFactory");
            if (armorDamageReductionFormulaFactory == null)
                throw new ArgumentNullException("armorDamageReductionFormulaFactory");
            if (resistanceDamageReductionFormulaFactory == null)
                throw new ArgumentNullException("resistanceDamageReductionFormulaFactory");
            if (dodgeDamageReductionFormulaFactory == null)
                throw new ArgumentNullException("dodgeDamageReductionFormulaFactory");
            if (otherDamageReductionFormulaFactory == null)
                throw new ArgumentNullException("otherDamageReductionFormulaFactory");
            _maxLifeFormulaFactory = maxLifeFormulaFactory;
            _armorDamageReductionFormulaFactory = armorDamageReductionFormulaFactory;
            _resistanceDamageReductionFormulaFactory = resistanceDamageReductionFormulaFactory;
            _dodgeDamageReductionFormulaFactory = dodgeDamageReductionFormulaFactory;
            _otherDamageReductionFormulaFactory = otherDamageReductionFormulaFactory;
        }

        public override ITerm CreateFormula()
        {
            return Factories.ProductFactory.CreateFormulaTerm(
                _maxLifeFormulaFactory.CreateFormula(),
                Factories.DivisionFactory.CreateFormulaTerm(
                    _armorDamageReductionFormulaFactory.CreateFormula(),
                    _resistanceDamageReductionFormulaFactory.CreateFormula(),
                    _dodgeDamageReductionFormulaFactory.CreateFormula(),
                    _otherDamageReductionFormulaFactory.CreateFormula()
                    )
                );
        }
    }
}