using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    public class CompoundSpecification<T> : Specification<T>
    {
        IEnumerable<Specification<T>> specifications;

        public CompoundSpecification(IEnumerable<Specification<T>> specs)
        {
            specifications = specs;
        }

        public bool is_satisfied_by(T item)
        {
            return specifications.All(specification => specification.is_satisfied_by(item));
        }
    }
}