using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewMainDepartments> {}

        [Concern(typeof (ViewMainDepartments))]
        public class when_command_is_processed : concern
        {
            context c = () =>
            {
                request = an<ApplicationRequest>();
                department_list = new List<DepartmentItem>();
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();
                catalog_tasks.Stub(x => x.get_all_main_departments()).Return(department_list);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_tell_the_response_engine_to_display_the_main_departments_in_the_store = () =>
            {
                response_engine.received(engine => engine.display(department_list));
            };

            static ApplicationRequest request;
            static CatalogTasks catalog_tasks;
            static IEnumerable<DepartmentItem> department_list;
            static ResponseEngine response_engine;
        }
    }
}