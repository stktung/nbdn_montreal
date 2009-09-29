namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsEqualToCriteria<T> : Criteria<T>
    {
        T value;

        public IsEqualToCriteria(T value)
        {
            this.value = value;
        }

        public bool is_satisfied_by(T item)
        {
            return item.Equals(value);
        }
    }
}