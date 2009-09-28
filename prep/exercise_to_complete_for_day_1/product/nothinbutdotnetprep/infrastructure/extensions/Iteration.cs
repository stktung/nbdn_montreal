using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class Iteration
    {
        static public IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        static public void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }

        static public IEnumerable<int> to(this int start, int end)
        {
            for (var i = start; i <= end; i++) yield return i;
        }
    }
}