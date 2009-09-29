using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<Item>
    {
        public static ComparerBuilder<Item> by<Property>(Func<Item, Property> property_accessor, params Property[] values)
        {
            return with(new CombinedPropertyComparer<Item,Property>(new FixedOrderComparer<Property>(values),property_accessor));
        }

        public static ComparerBuilder<Item> by<Property>(Func<Item, Property> property_accessor) where Property : IComparable, IComparable<Property>
        {
            return with(new PropertyComparer<Item, Property>(property_accessor));
        }

        public static ComparerBuilder<Item> by_descending<Property>(Func<Item, Property> property_accessor) where Property : IComparable, IComparable<Property>
        {
            return with(new InverseComparer<Item>(new PropertyComparer<Item, Property>(property_accessor)));
        }

        public static ComparerBuilder<Item> with<ComparerType>() where ComparerType : IComparer<Item>, new()
        {
            return with(new ComparerType());
        }

        public static ComparerBuilder<Item> with(IComparer<Item> comparer) 
        {
            return new ComparerBuilder<Item>(comparer);
        }
    }
}