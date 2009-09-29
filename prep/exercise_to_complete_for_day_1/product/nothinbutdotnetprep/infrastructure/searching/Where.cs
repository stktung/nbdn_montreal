using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        static public Func<ItemToFilter, Property> has_a<Property>(Func<ItemToFilter, Property> property_accessor)
        {
            return property_accessor;
        }
    }

    public static class FuncExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, Property>(this Func<ItemToFilter, Property> func, Property property) 
        {
            return new AnonymousCriteria<ItemToFilter>(itemToFilter => func(itemToFilter).Equals(property));
        }

        //public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, Property>(this Func<ItemToFilter, Property> func, Property property)
        //{
        //    return new AnonymousCriteria<ItemToFilter>(itemToFilter => func(itemToFilter).Equals(property));
        //}
    }

    class AnonymousCriteria<T> : Criteria<T>
    {
        readonly Predicate<T> predicate;

        public AnonymousCriteria(Predicate<T> predicate)
        {
            this.predicate = predicate;
        }

        public bool is_satisfied_by(T item)
        {
            return predicate(item);
        }
    }
}