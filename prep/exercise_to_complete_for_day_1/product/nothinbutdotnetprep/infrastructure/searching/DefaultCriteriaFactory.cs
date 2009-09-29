using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property>
    {
        Func<ItemToFilter, Property> property_accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, Property> accessor)
        {
            property_accessor = accessor;
        }

        public DefaultCriteriaFactory(Func<ItemToFilter, Property> accessor, bool negate)
        {
            property_accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(Property value_to_equal)
        {
            return new PropertyCriteria<ItemToFilter, Property>(property_accessor,
                                                                new IsEqualToCriteria<Property>(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            return new AnonymousCriteria<ItemToFilter>(
                item =>
                {
                    foreach (var value in values)
                    {
                        if (equal_to(value).is_satisfied_by(item))
                        {
                            return true;
                        }
                    }
                    return false;
                });
        }

        public CriteriaFactory<ItemToFilter, Property> not
        {
            get { return new NegatingCriteriaFactory<ItemToFilter, Property>(this); }
        }
    }
}