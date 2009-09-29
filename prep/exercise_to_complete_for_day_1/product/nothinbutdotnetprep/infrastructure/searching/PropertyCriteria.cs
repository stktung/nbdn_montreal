using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyCriteria<ItemToFilter,Property> : Criteria<ItemToFilter>
    {
        Func<ItemToFilter, Property> accessor;
        Criteria<Property> raw_criteria;

        public PropertyCriteria(Func<ItemToFilter, Property> accessor, Criteria<Property> raw_criteria)
        {
            this.accessor = accessor;
            this.raw_criteria = raw_criteria;
        }

        public bool is_satisfied_by(ItemToFilter item)
        {
            return raw_criteria.is_satisfied_by(accessor(item));
        }
    }
}