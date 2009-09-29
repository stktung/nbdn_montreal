using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerFactory<Item, Property> where Property : IComparable
    {
        Func<Item, Property> property_accessor;

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
                return new InverseComparer<Item>(ascending);
            }
        }
    }
}