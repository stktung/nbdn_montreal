using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property>
    {
        Func<ItemToFilter, Property> propery_accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, Property> accessor)
        {
            propery_accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(Property property_to_compare) 
        {
            return new AnonymousCriteria<ItemToFilter>(item => propery_accessor.Equals(property_to_compare));
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            throw new NotImplementedException();
        }
    }
}