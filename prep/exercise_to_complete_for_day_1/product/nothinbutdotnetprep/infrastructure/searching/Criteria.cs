namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Criteria<T> {
        bool is_satisfied_by(T item);
    }
}