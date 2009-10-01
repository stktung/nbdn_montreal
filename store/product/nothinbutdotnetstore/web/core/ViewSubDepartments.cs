using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class ViewSubDepartments : ApplicationWebCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;

        public ViewSubDepartments() : this(new StubCatalogTasks(), new StubResponseEngine()) {}


        public ViewSubDepartments(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(ApplicationRequest request)
        {
            response_engine.display(catalog_tasks.get_sub_departments_for(request.map<DepartmentItem>()));
        }
    }
}