using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;

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
                commandRegistry = the_dependency<CommandRegistry>();
            };

            because b = () =>
            {
                sut.process(someApplicationRequest);
            };


            it should_ask_the_command_registry_for_a_command_that_can_process_the_request = () =>
            {
                commandRegistry.received(registry => registry.Lookup(someApplicationRequest));
            };

            static ApplicationRequest someApplicationRequest;
            static CommandRegistry commandRegistry;
        }
    }
}