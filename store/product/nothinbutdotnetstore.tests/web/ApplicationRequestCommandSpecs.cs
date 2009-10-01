using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;
using developwithpassion.bdd.mocking.rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ApplicationRequestCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationRequestCommand,
                                            BasicApplicationRequestCommand>
        {
            static protected ApplicationRequest request;
        }

        [Concern(typeof (BasicApplicationRequestCommand))]
        public class when_determining_if_it_can_handle_a_request : concern
        {

            context c = () =>
            {
                request_specification = the_dependency<Specification<ApplicationRequest>>();
                request_specification.Stub(x => x.is_satisfied_by(request)).Return(true);
            };

            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_make_the_decision_by_leveraging_its_request_specification = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Specification<ApplicationRequest> request_specification;
        }

        [Concern(typeof (BasicApplicationRequestCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                application_command = the_dependency<ApplicationWebCommand>();
                request = an<ApplicationRequest>();
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_delegate_the_processing_to_the_application_specific_command = () =>
            {
                application_command.received(command => command.process(request));
            };

            static bool result;
            static ApplicationWebCommand application_command;
        }

        [Concern(typeof (BasicApplicationRequestCommand))]
        public class when_the_command_is_processed : concern
        {
            context c = () => {};

            because b = () => {};


            it first_observation = () => {};
        }
    }
}