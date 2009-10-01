using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FrontController,
                                            BasicFrontController> {}

        [Concern(typeof (BasicFrontController))]
        public class when_processing_an_application_request : concern
        {
            context c = () =>
            {
                some_request = an<ApplicationRequest>();
                command= an<ApplicationRequestCommand>();
                command_registry = the_dependency<CommandRegistry>();
                command_registry.Stub(x => x.find_command_that_can_process(some_request)).Return(command);
            };

            because b = () =>
            {
                sut.process(some_request);
            };

            it should_tell_the_command_that_can_process_the_request_to_process_it = () =>
            {
                command.received(request_command => request_command.process(some_request));
            };

            static ApplicationRequest some_request;
            static CommandRegistry command_registry;
            static ApplicationRequestCommand command;
        }
    }
}