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
                                            RequestHasSpecificCommandName>
        {
            protected static bool result;
            protected static ApplicationRequest request;
        }

        [Concern(typeof (RequestHasSpecificCommandName))]
        public class when_determining_whether_it_is_satisfied_by_a_request : concern
        {
            context c = () =>
            {
                command_name = "Whatever";
                provide_a_basic_sut_constructor_argument(command_name);
                request = an<ApplicationRequest>();
            };


            it should_not_be_satisfied_if_the_command_name_does_not_match = () =>
            {
                request.command_name = "blah";
                sut.is_satisfied_by(request).should_be_false();
            };

            it should_be_satisfied_if_the_request_contains_the_expected_command_name = () =>
            {
                request.command_name = command_name;
                sut.is_satisfied_by(request).should_be_true();
            };

            static string command_name;
        }
    }
}