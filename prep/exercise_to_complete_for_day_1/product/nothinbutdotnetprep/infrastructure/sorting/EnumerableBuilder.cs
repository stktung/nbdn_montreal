using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class EnumerableBuilder<ItemToSort> : IEnumerable<ItemToSort>
    {
        private readonly ComparerBuilder<ItemToSort> ComparerBuilder;
        private IEnumerable<ItemToSort> items;

        public EnumerableBuilder(ComparerBuilder<ItemToSort> comparerBuilder, IEnumerable<ItemToSort> items)
        {
            ComparerBuilder = comparerBuilder;
            this.items = items;
        }
        
        public EnumerableBuilder<ItemToSort> then_by<Property>(Func<ItemToSort, Property> accessor) where Property : IComparable<Property>
        {
            ComparerBuilder.then_by(accessor);
            return this;
        }

        public IEnumerator<ItemToSort> GetEnumerator()
        {
            return items.sort_all_using(ComparerBuilder).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public EnumerableBuilder<ItemToSort> then_by_descending<Property>(Func<ItemToSort, Property> accessor) where Property : IComparable<Property>
        {
            ComparerBuilder.then_by_descending(accessor);
            return this;
        }
    }
}