using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class SearchingExtensions
    {
        public static AnonymousCriteria<ItemToFilter> equal_to<ItemToFilter, Property>(this Func<ItemToFilter, Property> a, Property b)
        {
            return new AnonymousCriteria<ItemToFilter>(item => a(item).Equals(b));
        }
    }
}