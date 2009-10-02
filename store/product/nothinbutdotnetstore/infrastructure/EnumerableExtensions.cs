using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public static class EnumerableExtensions
    {
        public static void each<Item>(this IEnumerable<Item> items, Action<Item> action){
            foreach (var item in items)action(item);
        } 
    }
}