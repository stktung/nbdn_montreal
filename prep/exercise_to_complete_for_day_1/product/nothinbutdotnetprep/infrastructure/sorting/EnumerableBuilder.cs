using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class EnumerableBuilder<Item> : IEnumerable<Item>, EnumerableBuilder1<Item>, EnumerableBuilder2<Item>
    {
        private readonly ComparerBuilder<Item> ComparerBuilder;
        private IEnumerable<Item> items;

        public EnumerableBuilder(ComparerBuilder<Item> comparerBuilder, IEnumerable<Item> items)
        {
            ComparerBuilder = comparerBuilder;
            this.items = items;
        }

        public EnumerableBuilder<Item> by<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            return then_by(accessor);
        }

        public EnumerableBuilder<Item> by_descending<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            return then_by_descending(accessor);
        }

        public EnumerableBuilder<Item> then_by<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            ComparerBuilder.then_by(accessor);
            return this;
        }

        public EnumerableBuilder<Item> then_by_descending<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            ComparerBuilder.then_by_descending(accessor);
            return this;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return items.sort_all_using(ComparerBuilder).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public EnumerableBuilder<Item> with(ComparerBuilder<Item> comparer)
        {
            ComparerBuilder.then_using(comparer);
            return this;
        }
    }

    public interface EnumerableBuilder1<T>
    {
        EnumerableBuilder<T> with(ComparerBuilder<T> comparer);
        EnumerableBuilder<T> by<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
        EnumerableBuilder<T> by_descending<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
    }

    public interface EnumerableBuilder2<T>
    {
        EnumerableBuilder<T> then_by<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
        EnumerableBuilder<T> then_by_descending<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
    }

}