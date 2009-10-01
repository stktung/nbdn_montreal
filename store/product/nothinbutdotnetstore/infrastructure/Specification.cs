using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public interface Specification<T>
    {
        bool is_satisfied_by(T item);
    }
}