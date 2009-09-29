using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property> where Property : IComparable<Property>
    {
        Func<ItemToFilter, Property> property_accessor;
        CriteriaFactory<ItemToFilter, Property> basic_factory;
        bool negating;

        public ComparableCriteriaFactory(Func<ItemToFilter, Property> accessor, CriteriaFactory<ItemToFilter, Property> basic_factory, bool negating)
        {
            property_accessor = accessor;
            this.basic_factory = basic_factory;
            this.negating = negating;
        }

        public ComparableCriteriaFactory(Func<ItemToFilter, Property> accessor, CriteriaFactory<ItemToFilter, Property> basic_factory)
        {
            property_accessor = accessor;
            this.basic_factory = basic_factory;
            this.negating = false;
        }

        public Criteria<ItemToFilter> equal_to(Property property_to_compare)
        {
            return basic_factory.equal_to(property_to_compare);
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            return basic_factory.equal_to_any(values);
        }

        public CriteriaFactory<ItemToFilter, Property> not()
        {
           return new NegatingCriteriaFactory<ItemToFilter, Property>(new ComparableCriteriaFactory<ItemToFilter, Property>(property_accessor, new DefaultCriteriaFactory<ItemToFilter, Property>(property_accessor, true), true));
        }

        public Criteria<ItemToFilter> greater_than(Property value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(Property start, Property end)
        {
            return new AnonymousCriteria<ItemToFilter>(item =>
                                                       property_accessor(item).CompareTo(start) >= 0 && property_accessor(item).CompareTo(end) <= 0);
        }
    }
}