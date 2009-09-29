namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, Property>
    {
        Criteria<ItemToFilter> equal_to(Property propertyToCompare);
        Criteria<ItemToFilter> equal_to_any(params Property[] properties);
    }
}