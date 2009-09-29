using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property> where Property : IComparable<Property>
    {
        Func<ItemToFilter, Property> property_accessor;
        CriteriaFactory<ItemToFilter, Property> basic_factory;

        public ComparableCriteriaFactory(Func<ItemToFilter, Property> accessor, CriteriaFactory<ItemToFilter, Property> basic_factory)
        {
            property_accessor = accessor;
            this.basic_factory = basic_factory;
        }

        public Criteria<ItemToFilter> equal_to(Property value_to_equal)
        {
            return basic_factory.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            return basic_factory.equal_to_any(values);
        }

        public CriteriaFactory<ItemToFilter, Property> not
        {
            get
            {
                return
                    new NegatingCriteriaFactory<ItemToFilter, Property>(this);
            }
        }

        public Criteria<ItemToFilter> greater_than(Property value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(Property start, Property end)
        {
            return new PropertyCriteria<ItemToFilter, Property>(property_accessor,
                                                                new FallsInRangeCriteria<Property>(
                                                                    new InclusiveRange<Property>(start, end)));
        }
    }
}