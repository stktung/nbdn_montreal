namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, Property>
    {
        Criteria<ItemToFilter> equal_to(Property value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params Property[] properties);
        CriteriaFactory<ItemToFilter, Property> not { get; }
    }
}