using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class ViewSubDepartmentsOrProducts : ApplicationWebCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;

        public ViewSubDepartmentsOrProducts() : this(new StubCatalogTasks(), new StubResponseEngine()) {}


        public ViewSubDepartmentsOrProducts(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(ApplicationRequest request)

        {
            if (catalog_tasks.has_any_products(request.map<DepartmentItem>()))
            {
                response_engine.display(catalog_tasks.get_products_for(request.map<DepartmentItem>()));
            }
            else
            {
                response_engine.display(catalog_tasks.get_sub_departments_for(request.map<DepartmentItem>()));
            }
        }
    }
}