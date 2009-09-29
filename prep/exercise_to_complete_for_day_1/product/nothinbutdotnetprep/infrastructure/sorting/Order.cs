using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<Item>
    {
        public static IComparer<Item> by<Property>(Func<Item, Property> property_accessor) where Property : IComparable
        {
            return new PropertyComparer<Item, Property>(property_accessor);    
        }

        public static IComparer<Item> descending_by<Property>(Func<Item, Property> property_accessor) where Property : IComparable
        {
            return new InverseComparer<Item>(by(property_accessor));
        }

        public static IComparer<Item> with<Comparer>() where Comparer : IComparer<Item>, new()
        {
            return new Comparer();
        }
    }
}