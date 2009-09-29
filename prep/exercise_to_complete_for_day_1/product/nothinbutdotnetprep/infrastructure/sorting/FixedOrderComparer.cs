using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class FixedOrderComparer<Item, Property> : IComparer<Item>
    {
        readonly Func<Item, Property> accessor;
        readonly Property[] fixed_order;

        public FixedOrderComparer(Func<Item, Property> accessor, Property[] fixedOrder)
        {
            this.accessor = accessor;
            fixed_order = fixedOrder;
        }

        public int Compare(Item x, Item y)
        {
            var listValues = new List<Property>(fixed_order);

            return listValues.IndexOf(accessor(x)).
                CompareTo(listValues.IndexOf(accessor(y)));
        }
    }
}