using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                            BasicResponseEngine> {}

        [Concern(typeof (BasicResponseEngine))]
        public class when_the_engine_is_asked_to_display_a_model : concern
        {
            context c = () =>
            {
                model = new object();
                view_registry = the_dependency<ViewRegistry>();

            };

            because b = () =>
            {
                sut.display(model);
            };

            it should_call_into_the_view_registry = () =>
            {
                view_registry.received(registry => registry.find_view_that_can_process<object>());
            };

            static object model;
            static ViewRegistry view_registry;
        }
    }
}