namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingCriteriaFactory<ItemToFilter, Property> : CriteriaFactory<ItemToFilter, Property> {

        CriteriaFactory<ItemToFilter, Property> base_criteria_factory;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToFilter, Property> default_criteria_factory)
        {
            this.base_criteria_factory = default_criteria_factory;
        }

        public Criteria<ItemToFilter> equal_to(Property value_to_equal)
        {
            return new NotCriteria<ItemToFilter>(base_criteria_factory.equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params Property[] values)
        {
            return new NotCriteria<ItemToFilter>(base_criteria_factory.equal_to_any(values));
        }

        public CriteriaFactory<ItemToFilter, Property> not
        {
            get { return this;}
        }
    }
}