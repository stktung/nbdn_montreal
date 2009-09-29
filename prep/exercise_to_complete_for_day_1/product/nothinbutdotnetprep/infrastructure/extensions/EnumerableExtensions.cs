using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Criteria<T> filter)
        {
            return all_items_matching(items,filter.is_satisfied_by);
        }
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Filter<T> filter)
        {
            foreach (var item in items)
            {
                if (filter(item)) yield return item;
            }
        }
    }
}