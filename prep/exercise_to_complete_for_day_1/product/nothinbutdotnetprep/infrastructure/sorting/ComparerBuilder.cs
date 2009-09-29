using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> final_comparer;

        public ComparerBuilder(IComparer<ItemToSort> initial_comparer)
        {
            final_comparer = initial_comparer;
        }

        public ComparerBuilder<ItemToSort> then_using(IComparer<ItemToSort> comparer)
        {
            final_comparer = new ChainedComparer<ItemToSort>(final_comparer, comparer);
            return this;
        }

        public ComparerBuilder<ItemToSort> then_by_descending<Property>(Func<ItemToSort, Property> accessor) where Property : IComparable<Property> 
        {
            return then_using(new InverseComparer<ItemToSort>(new PropertyComparer<ItemToSort, Property>(accessor)));
        }

        public ComparerBuilder<ItemToSort> then_by<Property>(Func<ItemToSort, Property> accessor) where Property : IComparable<Property>
        {
            return then_using(new PropertyComparer<ItemToSort, Property>(accessor));
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return final_comparer.Compare(x, y);
        }
    }
}