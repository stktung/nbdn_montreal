using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Startup))]
        public class when_the_application_starts_up : concern
        {
            because b = () =>
            {
                Startup.go();
            };


            it should_be_able_able_to_access_key_application_components_from_the_container = () =>
            {
                IOC.resolve.instance_of<FrontController>().should_be_an_instance_of<BasicFrontController>();
            };
        }
    }
}