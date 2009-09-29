namespace nothinbutdotnetprep.infrastructure.searching
{
    public class SignedCriteria<T> : Criteria<T>
    {
        Filter<T> condition;
        bool negative;

        public SignedCriteria(Filter<T> condition)
        {
            this.condition = condition;
            negative = false;
        }

        public SignedCriteria(Filter<T> condition, bool negative)
        {
            this.condition = condition;
            this.negative = negative;
        }

        public bool is_satisfied_by(T item)
        {
            return negative ? !condition(item) : condition(item);
        }
    }
}