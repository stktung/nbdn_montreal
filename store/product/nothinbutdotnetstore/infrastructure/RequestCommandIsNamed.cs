using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public class RequestHasSpecificFileName : Specification<ApplicationRequest>
    {
        string expected_file_name;

        public RequestHasSpecificFileName(string expected_file_name)
        {
            this.expected_file_name = expected_file_name;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return item.raw_url.Contains(expected_file_name);
        }
    }


    public class DepartmentHasProducts : Specification<ApplicationRequest>
    {
        CatalogTasks tasks;

        public DepartmentHasProducts():this(new StubCatalogTasks()) {}

        public DepartmentHasProducts(CatalogTasks tasks)
        {
            this.tasks = tasks;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return tasks.has_any_products(item.map<DepartmentItem>());
        }
    }


    public class RequestHasSpecificId : Specification<ApplicationRequest>
    {
        string id;

        public RequestHasSpecificId(string id)
        {
            this.id = id;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return item.id == id;
        }
    }

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