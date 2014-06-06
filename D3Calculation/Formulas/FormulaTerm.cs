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
        private readonly string _sOperator;

        public FormulaTerm(IList<ITerm> terms, double seed, Func<double,ITerm,double> aggregateFunc, string sOperator)
        {
            if (terms == null) throw new ArgumentNullException("terms");
            if (aggregateFunc == null) throw new ArgumentNullException("aggregateFunc");
            if (sOperator == null) throw new ArgumentNullException("sOperator");
            _terms = terms;
            _seed = seed;
            _aggregateFunc = aggregateFunc;
            _sOperator = sOperator;
        }

        public virtual double Evaluate()
        {
            return _terms.Aggregate(_seed, _aggregateFunc);
        }

        public override string ToString()
        {
            return "( " + _terms.Aggregate(_seed.ToString("0.###"), (accumulator, current) => accumulator + " " + _sOperator + " " + current.ToString()) + " )";
        }
    }
}