namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AnonymousCriteria<T> : Criteria<T>
    {
        Filter<T> condition;

        public AnonymousCriteria(Filter<T> condition)
        {
            this.condition = condition;
        }

        public bool is_satisfied_by(T item)
        {
            return condition(item);
        }
    }
}