using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToSort>
    {
        public static ComparerFactory<ItemToSort, Property> by<Property>(Func<ItemToSort, Property> property_accessor) where Property : IComparable
        {
            return new ComparerFactory<ItemToSort, Property>(property_accessor);    
        }
    }

    public class ComparerFactory<Item, Property> where Property : IComparable
    {
        readonly Func<Item, Property> property_accessor;

        public ComparerFactory(Func<Item, Property> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public IComparer<Item> ascending 
        {
            get 
            {
                return new PropertyComparer<Item, Property>(property_accessor);
            }
        }

        public IComparer<Item> descending
        {
            get
            {
                return new InverseComparer<Item>(new PropertyComparer<Item, Property>(property_accessor));
            }
        }
    }

    public class InverseComparer<Item> : IComparer<Item> {
        readonly IComparer<Item> item_comparer;

        public InverseComparer(IComparer<Item> item_comparer)
        {
            this.item_comparer = item_comparer;
        }

        public int Compare(Item x, Item y)
        {
            return item_comparer.Compare(y, x);
        }
    }

    public class PropertyComparer<Item, Property> : IComparer<Item> where Property : IComparable
    {
        readonly Func<Item, Property> property_accessor;

        public PropertyComparer(Func<Item, Property> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public int Compare(Item x, Item y)
        {
            return property_accessor(x).CompareTo(property_accessor(y));
        }
    }
}