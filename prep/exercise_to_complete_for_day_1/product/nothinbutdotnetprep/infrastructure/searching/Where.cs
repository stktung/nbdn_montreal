using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        static public CriteriaFactory<ItemToFilter, Property> has_a<Property>(Func<ItemToFilter, Property> property_accessor) {
            
            var factory = new CriteriaFactory<ItemToFilter, Property>(property_accessor);
            return factory;
        }
    }

    public class CriteriaFactory<ItemToFilter, Property> {

        Func<ItemToFilter, Property> propery_accessor;

        public CriteriaFactory(Func<ItemToFilter, Property> accessor)
        {
            propery_accessor = accessor;
        }

        public AnonymousCriteria<ItemToFilter> is_equal_to(Property propertyToCompare) 
        {
            return new AnonymousCriteria<ItemToFilter>(item => propery_accessor.Equals(propertyToCompare));
        }

    }
}