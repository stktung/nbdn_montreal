using System.Collections.Generic;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewDepartmentsCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationWebCommand,
                                            ViewDepartmentsCommand> {}

        [Concern(typeof (ViewDepartmentsCommand))]
        public class when_command_is_processed : concern
        {
            context c = () =>
            {
                departmentList = new List<string> {"foo", "bar"};
                service = the_dependency<Service>();
                departmentView = the_dependency<DepartmentView>();
                service.Stub(x => x.GetDepartments()).Return(departmentList);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_get_a_list_of_departments_and_push_to_view = () =>
            {
                departmentView.Departments.should_contain(departmentList.ToArray());
            };

            static ApplicationRequest request;
            static DepartmentView departmentView;
            static Service service;
            static List<string> departmentList;
        }
    }

   
}