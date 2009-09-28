using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Criteria<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria(item)) yield return item;
            }
        }
    }
}