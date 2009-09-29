namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, Property>
    {
        AnonymousCriteria<ItemToFilter> equal_to(Property propertyToCompare);
        AnonymousCriteria<ItemToFilter> equal_to_any(params Property[] values);
    }
}