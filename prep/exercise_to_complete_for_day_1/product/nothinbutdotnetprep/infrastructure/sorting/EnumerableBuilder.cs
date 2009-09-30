using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class EnumerableBuilder<Item> : IEnumerable<Item>, EnumerableBuilderStartExpression<Item>, EnumerableBuilderContinuationExpression<Item>
    {
        private readonly ComparerBuilder<Item> ComparerBuilder;
        private IEnumerable<Item> items;

        public EnumerableBuilder(ComparerBuilder<Item> comparerBuilder, IEnumerable<Item> items)
        {
            ComparerBuilder = comparerBuilder;
            this.items = items;
        }

        public EnumerableBuilderContinuationExpression<Item> by<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            return then_by(accessor);
        }

        public EnumerableBuilderContinuationExpression<Item> by_descending<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            return then_by_descending(accessor);
        }

        public EnumerableBuilderContinuationExpression<Item> then_by<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
        {
            ComparerBuilder.then_by(accessor);
            return this;
        }

        public EnumerableBuilderContinuationExpression<Item> then_by_descending<Property>(Func<Item, Property> accessor) where Property : IComparable<Property>
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

        public EnumerableBuilderContinuationExpression<Item> with(ComparerBuilder<Item> comparer)
        {
            ComparerBuilder.then_using(comparer);
            return this;
        }
    }

    public interface EnumerableBuilderStartExpression<T> : IEnumerable<T>
    {
        EnumerableBuilderContinuationExpression<T> with(ComparerBuilder<T> comparer);
        EnumerableBuilderContinuationExpression<T> by<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
        EnumerableBuilderContinuationExpression<T> by_descending<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
    }

    public interface EnumerableBuilderContinuationExpression<T> : IEnumerable<T>
    {
        EnumerableBuilderContinuationExpression<T> then_by<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
        EnumerableBuilderContinuationExpression<T> then_by_descending<Property>(Func<T, Property> accessor) where Property : IComparable<Property>;
    }

}