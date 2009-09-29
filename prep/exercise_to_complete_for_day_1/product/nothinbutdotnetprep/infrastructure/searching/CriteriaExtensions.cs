namespace nothinbutdotnetprep.infrastructure.searching
{
    static public class CriteriaExtensions
    {
        static public Criteria<T> or<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new OrCriteria<T>(left_side, right_side);
        }

        static public Criteria<T> and<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new AndCriteria<T>(left_side, right_side);
        }
    }
}