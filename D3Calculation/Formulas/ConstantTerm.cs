namespace D3Calculation.Formulas
{
    public class ConstantTerm : ITerm
    {
        private readonly double _constant;

        public ConstantTerm(double constant)
        {
            _constant = constant;
        }

        public double Evaluate()
        {
            return _constant;
        }
    }
}