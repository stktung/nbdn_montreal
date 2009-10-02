using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class ViewSubDepartmentsInDepartment : ApplicationWebCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;

        public ViewSubDepartmentsInDepartment() : this(new StubCatalogTasks(), new StubResponseEngine()) {}


        public ViewSubDepartmentsInDepartment(CatalogTasks catalog_tasks, ResponseEngine response_engine)
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