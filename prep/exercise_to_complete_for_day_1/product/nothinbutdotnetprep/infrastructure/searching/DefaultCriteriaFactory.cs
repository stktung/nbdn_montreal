using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property>
    {
        Func<ItemToFilter, Property> property_accessor;
        bool negate;

        public DefaultCriteriaFactory(Func<ItemToFilter, Property> accessor)
        {
            property_accessor = accessor;
            negate = false;
        }

        public DefaultCriteriaFactory(Func<ItemToFilter, Property> accessor, bool negate)
        {
            property_accessor = accessor;
            this.negate = negate;
        }

        public Criteria<ItemToFilter> equal_to(Property property_to_compare)
        {
            return new SignedCriteria<ItemToFilter>(item => property_accessor(item).Equals(property_to_compare),negate);
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            return new SignedCriteria<ItemToFilter>(
                item =>
                {
                    foreach (var value in values)
                    {
                        if (property_accessor(item).Equals(value))
                        {
                            return true;
                        }
                    }
                    return false;
                }, negate
                );
        }

        public CriteriaFactory<ItemToFilter, Property> not()
        {
            return new NegatingCriteriaFactory<ItemToFilter, Property>(new DefaultCriteriaFactory<ItemToFilter, Property>(property_accessor,true));
        }
    }

    public class NegatingCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property> {

        readonly CriteriaFactory<ItemToFilter, Property> base_criteria_factory;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToFilter, Property> default_criteria_factory)
        {
            this.base_criteria_factory = default_criteria_factory;
        }

        public Criteria<ItemToFilter> equal_to(Property property_to_compare)
        {
            return base_criteria_factory.equal_to(property_to_compare);
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            return base_criteria_factory.equal_to_any(values);
        }

        public CriteriaFactory<ItemToFilter, Property> not()
        {
            return base_criteria_factory.not();
        }
    }
}