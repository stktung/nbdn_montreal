using System.Collections.Generic;
using System.Web.Compilation;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewProductsInDepartmentSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewProductsInDepartment> {}

        [Concern(typeof (ViewProductsInDepartment))]
        public class when_command_is_processed : concern
        {
            context c = () =>
            {
                request = an<ApplicationRequest>();
                some_department = an<DepartmentItem>();
                product_list = new List<ProductItem>();
                
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();
                request.Stub(application_request => application_request.map<DepartmentItem>()).Return(some_department);
                catalog_tasks.Stub(x => x.get_products_for(some_department)).Return(product_list);
            };

            because b = () =>
            {
                sut.process(request);
            };

            it should_tell_the_response_engine_to_display_the_content = () =>
            {
                response_engine.received(engine => engine.display(product_list));
            };

            static ApplicationRequest request;
            static IEnumerable<ProductItem> product_list;
            static CatalogTasks catalog_tasks;
            static ResponseEngine response_engine;
            static DepartmentItem some_department;
        }
    }
}