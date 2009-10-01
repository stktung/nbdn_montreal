using System.Collections.Generic;
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
    public class ViewSubDepartmentSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewSubDepartments> {}

        [Concern(typeof (ViewSubDepartments))]
        public class when_command_is_processed : concern
        {
            context c = () =>
            {
                request = an<ApplicationRequest>();
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();
                some_department = an<DepartmentItem>();

                catalog_tasks.Stub(x => x.get_sub_departments_for(some_department)).Return(department_list);

                request.Stub(application_request => application_request.map<DepartmentItem>()).Return(some_department);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_tell_the_response_engine_to_display_the_content = () =>
            {
                response_engine.received(engine => engine.display(department_list));
            };

            static ApplicationRequest request;
            static ResponseEngine response_engine;
            static IEnumerable<DepartmentItem> department_list;
            static CatalogTasks catalog_tasks;
            static DepartmentItem some_department;
        }
    }
}