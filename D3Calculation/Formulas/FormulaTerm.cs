using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace D3Calculation.Formulas
{
    public class FormulaTerm : ITerm
    {
        protected readonly IList<ITerm> _terms;
        private readonly double _seed;
        private readonly Func<double, ITerm, double> _aggregateFunc;

        public FormulaTerm(IList<ITerm> terms, double seed, Func<double,ITerm,double> aggregateFunc)
        {
            if (terms == null) throw new ArgumentNullException("terms");
            if (aggregateFunc == null) throw new ArgumentNullException("aggregateFunc");
            _terms = terms;
            _seed = seed;
            _aggregateFunc = aggregateFunc;
        }

        public virtual double Evaluate()
        {
            return _terms.Aggregate(_seed, _aggregateFunc);
        }

        public override string ToString()
        {
            return "(" + _terms.Aggregate(_seed.ToString("0.###"), (accumulator, current) => accumulator + _aggregateFunc.ToString() + current.ToString()) + ")";
        }
    }
}