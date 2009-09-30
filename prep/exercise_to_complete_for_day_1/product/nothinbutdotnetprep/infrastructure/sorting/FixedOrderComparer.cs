using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class FixedOrderComparer<Property> : IComparer<Property>
    {
        readonly Property[] fixed_order;

        public FixedOrderComparer(Property[] fixedOrder)
        {
            fixed_order = fixedOrder;
        }

        public int Compare(Property x, Property y)
        {
            var listValues = new List<Property>(fixed_order);

            return listValues.IndexOf(x).
                CompareTo(listValues.IndexOf(y));
        }
    }
}