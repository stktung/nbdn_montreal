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
            return new ComparableCriteriaFactory<ItemToFilter, Property>(property_accessor);
        }
    }

    public class ComparableCriteriaFactory<ItemToFilter, Property> where Property : IComparable<Property>
    {
        Func<ItemToFilter, Property> property_accessor;

        public ComparableCriteriaFactory(Func<ItemToFilter, Property> accessor)
        {
            property_accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(Property property_to_compare) {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item) == property_to_compare);
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            throw new NotImplementedException();
        }
    }

}