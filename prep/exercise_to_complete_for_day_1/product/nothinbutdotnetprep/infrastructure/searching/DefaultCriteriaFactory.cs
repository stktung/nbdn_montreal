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

        public AnonymousCriteria<ItemToFilter> equal_to(Property propertyToCompare) 
        {
            return new AnonymousCriteria<ItemToFilter>(item => propery_accessor.Equals(propertyToCompare));
        }

    }
}