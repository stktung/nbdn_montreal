using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                            BasicResponseEngine> {}


        public class when_creating_the_engine : concern
        {
            context c = () => {};

            because b = () => {};


            it should_not_blow_up = () =>
            {
                

            };
        }
        [Concern(typeof (BasicResponseEngine))]
        public class when_the_engine_is_asked_to_display_a_model : concern
        {
            context c = () =>
            {
                model = new object();
                view_registry = the_dependency<ViewRegistry>();
                view = an<ViewForModel<object>>();
                view_registry.Stub(registry => registry.find_view_that_can_process<object>()).Return(view);

                TransferAction  action = ((handler,preserve) =>
                {
                    page_that_was_transferred_to = handler as ViewForModel<object>;
                    preserve_the_form = preserve;
                });

                change(() => BasicResponseEngine.transfer_action).to(action);
            };

            because b = () =>
            {
                sut.display(model);
            };

            it should_have_populated_the_view_with_its_model = () =>
            {
                view.model.should_be_equal_to(model);
            };

            it should_tell_the_view_that_can_display_the_model_to_render = () =>
            {
                page_that_was_transferred_to.should_be_equal_to(view);
                preserve_the_form.should_be_true();
            };

            static object model;
            static ViewRegistry view_registry;
            static ViewForModel<object> view;
            static ViewForModel<object> page_that_was_transferred_to;
            static bool preserve_the_form;
        }
    }
}