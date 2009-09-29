using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        static public Func<ItemToFilter, Property> has_a<Property>(Func<ItemToFilter, Property> property_accessor) {

            return property_accessor;
        }
    }
}