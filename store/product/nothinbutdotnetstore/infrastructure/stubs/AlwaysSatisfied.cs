namespace nothinbutdotnetstore.infrastructure.stubs
{
    public class AlwaysSatisfied<T> : Specification<T>
    {
        public bool is_satisfied_by(T item)
        {
            return true;
        }
    }
}