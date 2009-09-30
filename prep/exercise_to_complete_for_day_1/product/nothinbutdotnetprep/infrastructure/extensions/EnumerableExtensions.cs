using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Criteria<T> filter)
        {
            return all_items_matching(items,filter.is_satisfied_by);
        }

        public static IEnumerable<T> sort_all_using<T>(this IEnumerable<T> items,IComparer<T> comparer)
        {
            return items.sort_all_using(comparer.Compare);
        }

        public static IEnumerable<T> sort_all_using<T>(this IEnumerable<T> items,Comparison<T> comparer)
        {
            var sorted = new List<T>(items);
            sorted.Sort(comparer);
            return sorted;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Filter<T> filter)
        {
            foreach (var item in items)
            {
                if (filter(item)) yield return item;
            }
        }

        public static EnumerableBuilder<Item> sort<Item>(this IEnumerable<Item> items) 
        {
            return new EnumerableBuilder<Item>(new ComparerBuilder<Item>(new DoNothingComparer<Item>()), items);
        }
    }
}