using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
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


    public class IfItHasProducts : Specification<ApplicationRequest>
    {
        CatalogTasks tasks;
        
        public IfItHasProducts(CatalogTasks tasks)
        {
            this.tasks = tasks;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return tasks.has_any_products(tasks.get_department_by_id(item.id)); 
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
            foreach (var specification in specifications)
            {
                if (!specification.is_satisfied_by(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}