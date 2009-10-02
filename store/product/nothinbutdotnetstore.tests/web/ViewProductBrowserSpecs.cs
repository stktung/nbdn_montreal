using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewProductBrowserSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewProductBrowser>
        {
            context c = () => {};
        }


        public class when_command_is_processed_that_has_products : concern
        {
            context c = () =>
            {
                request = an<ApplicationRequest>();
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();
                some_department = an<DepartmentItem>();

                catalog_tasks.Stub(x => x.get_products_for(some_department)).Return(product_list);
                request.Stub(application_request => application_request.map<DepartmentItem>()).Return(some_department);
            };

            because b = () =>
            {
                sut.process(request);
            };

            it should_tell_the_response_engine_to_display = () =>
            {
                response_engine.received(engine => engine.display(product_list));
            };

            static ApplicationRequest request;
            static ResponseEngine response_engine;
            static CatalogTasks catalog_tasks;
            static DepartmentItem some_department;
            static IEnumerable<ProductItem> product_list;
        }
    }
}