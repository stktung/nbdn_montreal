using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductBrowser : ApplicationWebCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;


        public ViewProductBrowser(CatalogTasks catalog_tasks, ResponseEngine response_engine)
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