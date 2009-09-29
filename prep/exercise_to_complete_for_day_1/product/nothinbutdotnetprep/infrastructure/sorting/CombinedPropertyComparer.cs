using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class CombinedPropertyComparer<ItemToSort,PropertyToSortOn> : IComparer<ItemToSort>
    {
        IComparer<PropertyToSortOn> raw_comparer;
        Func<ItemToSort,PropertyToSortOn> accessor;

        public CombinedPropertyComparer(IComparer<PropertyToSortOn> raw_comparer, Func<ItemToSort, PropertyToSortOn> accessor)
        {
            this.raw_comparer = raw_comparer;
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return raw_comparer.Compare(accessor(x), accessor(y));
        }
    }
}