using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public abstract class AbstractItemsFormulaFactory : AbstractFormulaFactory
    {
        protected readonly EventHandler<IList<Item>> ItemsChangedHandler;

        protected AbstractItemsFormulaFactory(ElementalTermFactories factories, EventHandler<IList<Item>> itemsChangedHandler)
            : base(factories)
        {
            if (itemsChangedHandler == null) throw new ArgumentNullException("itemsChangedHandler");
            ItemsChangedHandler = itemsChangedHandler;
        }
    }

    public abstract class AbstractFormulaFactory : IFormulaFactory
    {
        protected readonly ElementalTermFactories Factories;

        protected AbstractFormulaFactory(ElementalTermFactories factories)
        {
            if (factories == null) throw new ArgumentNullException("factories");
            Factories = factories;
        }

        public abstract ITerm CreateFormula();
    }
}