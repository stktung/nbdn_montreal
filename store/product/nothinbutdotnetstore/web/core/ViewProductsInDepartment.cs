using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core
{
    public class ViewProductsInDepartment : ApplicationWebCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;

        public ViewProductsInDepartment(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(ApplicationRequest request)
        {
            response_engine.display(catalog_tasks.get_products_for(request.map<DepartmentItem>()));
        }
    }
}