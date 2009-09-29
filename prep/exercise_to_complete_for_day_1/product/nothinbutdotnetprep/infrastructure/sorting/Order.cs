using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToSort>
    {
        public static ComparerFactory<ItemToSort, Property> by<Property>(Func<ItemToSort, Property> property_accessor) where Property : IComparable
        {
            return new ComparerFactory<ItemToSort, Property>(property_accessor);    
        }
    }
}