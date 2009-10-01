using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ApplicationRequestSpecificationSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Specification<ApplicationRequest>,
                                            CommandNameSpecification>
        {
            protected static bool result;
            protected static ApplicationRequest request;
        }

        [Concern(typeof (CommandNameSpecification))]
        public class when_the_specification_receives_a_request_that_asks_for_view_main_departments : concern
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument("ViewMainDepartment");
                request = an<ApplicationRequest>();
                request.command_name = "ViewMainDepartment";
            };

            because b = () =>
            {
                result = sut.is_satisfied_by(request);
            };

            it should_be_satisfied = () =>
            {
                result.should_be_true();
            };
        }

        [Concern(typeof (CommandNameSpecification))]
        public class when_the_specification_receives_a_request_that_asks_for_some_other_command : concern
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument("ViewMainDepartment");
                request = an<ApplicationRequest>();
                request.command_name = "SomeOtherCommand";
            };

            because b = () =>
            {
                result = sut.is_satisfied_by(request);
            };

            it should_not_be_satisfied = () =>
            {
                result.should_be_false();
            };
        }
    }
}