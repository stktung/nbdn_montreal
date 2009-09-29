using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property>
    {
        Func<ItemToFilter, Property> property_accessor;
        Predicate<ItemToFilter> property_accessor_comparer;
        bool not_condition;

        public DefaultCriteriaFactory(Func<ItemToFilter, Property> accessor)
        {
            property_accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(Property property_to_compare) 
        {
            return new AnonymousCriteria<ItemToFilter>(item =>
            {
                var equals = property_accessor(item).Equals(property_to_compare);
                if (not_condition)
                {
                    return !equals;
                }
                else 
                {
                    return equals;
                }
            });
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] properties)
        {
            return new AnonymousCriteria<ItemToFilter>(item =>
            {
                foreach (var property in properties)
                {
                    if (property_accessor(item).Equals(property))
                    {
                        return true;
                    }   
                }

                return false;
            });
        }

        public DefaultCriteriaFactory<ItemToFilter, Property> not
        {
            get 
            {
                not_condition = !not_condition;
                return this;
            }
        }
    }
}