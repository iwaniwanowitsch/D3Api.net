using System;
using System.Collections.Generic;

namespace D3Calculation.Formulas
{
    public class AverageTermFactory : AbstractTermFactory
    {
        private readonly SumTermFactory _sumFactory;
        private readonly ProductTermFactory _productFactory;
        private readonly DivisionTermFactory _divisionFactory;

        public AverageTermFactory(SumTermFactory sumFactory, ProductTermFactory productFactory,
            DivisionTermFactory divisionFactory)
        {
            if (sumFactory == null) throw new ArgumentNullException("sumFactory");
            if (productFactory == null) throw new ArgumentNullException("productFactory");
            if (divisionFactory == null) throw new ArgumentNullException("divisionFactory");
            _sumFactory = sumFactory;
            _productFactory = productFactory;
            _divisionFactory = divisionFactory;
        }

        public override ITerm CreateFormulaTerm(params ITerm[] terms)
        {
            return
                terms.Length != 0
                    ? _productFactory.CreateFormulaTerm(_sumFactory.CreateFormulaTerm(terms),
                        _divisionFactory.CreateFormulaTerm(_divisionFactory.CreateConstantTerm(terms.Length)))
                    : _sumFactory.CreateConstantTerm(0);
        }
    }
}