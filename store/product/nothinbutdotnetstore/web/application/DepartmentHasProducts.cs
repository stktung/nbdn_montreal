using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentHasProducts : Specification<ApplicationRequest>
    {
        CatalogTasks tasks;

        public DepartmentHasProducts() : this(new StubCatalogTasks()) {}

        public DepartmentHasProducts(CatalogTasks tasks)
        {
            this.tasks = tasks;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return tasks.has_any_products(item.map<DepartmentItem>());
        }
    }
}