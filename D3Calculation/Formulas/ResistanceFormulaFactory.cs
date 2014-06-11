using System;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class ResistanceFormulaFactory : AbstractFormulaFactory
    {
        private readonly ElementalResistanceFormulaFactory<PhysicalResistFetcher> _physResistFormula;
        private readonly ElementalResistanceFormulaFactory<ColdResistFetcher> _coldResistFormula;
        private readonly ElementalResistanceFormulaFactory<FireResistFetcher> _fireResistFormula;
        private readonly ElementalResistanceFormulaFactory<LightningResistFetcher> _lightResistFormula;
        private readonly ElementalResistanceFormulaFactory<PoisonResistFetcher> _poisonResistFormula;
        private readonly ElementalResistanceFormulaFactory<ArcaneResistFetcher> _arcaneResistFormula;

        public ResistanceFormulaFactory(ElementalTermFactories factories, ElementalResistanceFormulaFactory<PhysicalResistFetcher> physResistFormula, ElementalResistanceFormulaFactory<ColdResistFetcher> coldResistFormula, ElementalResistanceFormulaFactory<FireResistFetcher> fireResistFormula, ElementalResistanceFormulaFactory<LightningResistFetcher> lightResistFormula, ElementalResistanceFormulaFactory<PoisonResistFetcher> poisonResistFormula, ElementalResistanceFormulaFactory<ArcaneResistFetcher> arcaneResistFormula)
            : base(factories)
        {
            if (physResistFormula == null) throw new ArgumentNullException("physResistFormula");
            if (coldResistFormula == null) throw new ArgumentNullException("coldResistFormula");
            if (fireResistFormula == null) throw new ArgumentNullException("fireResistFormula");
            if (lightResistFormula == null) throw new ArgumentNullException("lightResistFormula");
            if (poisonResistFormula == null) throw new ArgumentNullException("poisonResistFormula");
            if (arcaneResistFormula == null) throw new ArgumentNullException("arcaneResistFormula");
            _physResistFormula = physResistFormula;
            _coldResistFormula = coldResistFormula;
            _fireResistFormula = fireResistFormula;
            _lightResistFormula = lightResistFormula;
            _poisonResistFormula = poisonResistFormula;
            _arcaneResistFormula = arcaneResistFormula;
        }

        public override ITerm CreateFormula()
        {
            return Factories.AverageFactory.CreateFormulaTerm(_physResistFormula.CreateFormula(), _coldResistFormula.CreateFormula(),
                _fireResistFormula.CreateFormula(), _lightResistFormula.CreateFormula(),
                _poisonResistFormula.CreateFormula(), _arcaneResistFormula.CreateFormula());
        }
    }
}