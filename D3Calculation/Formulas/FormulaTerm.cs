using System;
using System.Collections.Generic;
using System.Linq;

namespace D3Calculation.Formulas
{
    public class FormulaTerm : ITerm
    {
        protected readonly List<ITerm> _terms;
        private readonly double _seed;
        private readonly Func<double, ITerm, double> _aggregateFunc;

        public FormulaTerm(List<ITerm> terms, double seed, Func<double,ITerm,double> aggregateFunc)
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
    }
}