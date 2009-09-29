using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        static public DefaultCriteriaFactory<ItemToFilter, Property> has_a<Property>(Func<ItemToFilter, Property> property_accessor)
        {
            return new DefaultCriteriaFactory<ItemToFilter, Property>(property_accessor);
        }

        static public ComparableCriteriaFactory<ItemToFilter, Property> has_an<Property>(Func<ItemToFilter, Property> property_accessor) where Property : IComparable<Property>
        {
            return new ComparableCriteriaFactory<ItemToFilter, Property>(property_accessor, 
                                                                        new DefaultCriteriaFactory<ItemToFilter, Property>(property_accessor));
        }
    }
}