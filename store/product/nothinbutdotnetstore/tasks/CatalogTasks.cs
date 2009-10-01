using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<DepartmentItem> get_all_main_departments();
        IEnumerable<DepartmentItem> get_sub_departments_for(DepartmentItem department);
        IEnumerable<ProductItem> get_products_for(DepartmentItem department);
        bool has_any_products(DepartmentItem department);
    }
}