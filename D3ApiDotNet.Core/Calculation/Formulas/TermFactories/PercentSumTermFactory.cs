namespace D3ApiDotNet.Core.Calculation.Formulas.TermFactories
{
    public class PercentSumTermFactory : AbstractTermFactory
    {
        public override ITerm CreateFormulaTerm(params ITerm[] terms)
        {
            return new FormulaTerm(terms, 1.0, (accumulator, current) => accumulator + current.Evaluate(),"+");
        }
    }
}