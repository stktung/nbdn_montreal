using System;
using System.Collections.Generic;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ViewRegistry,
                                            BasicViewRegistry> {}


        public class MyPage : BasicViewForModel<object> {

        }
        [Concern(typeof (BasicViewRegistry))]
        public class when_getting_a_view_for_a_model_and_it_has_the_view : concern
        {
            context c = () =>
            {
                list_of_views = new Dictionary<Type, Type>();
                list_of_views.Add(typeof (object), typeof (MyPage));
                page = an<ViewForModel<object>>();

                ViewFactory view_factory = (path, type) =>
                {
                    path_requested = path;
                    return page;
                };
                provide_a_basic_sut_constructor_argument(list_of_views);
                change(() => BasicViewRegistry.view_factory).to(view_factory);
            };



            because b = () =>
            {
                result = sut.find_view_that_can_process<object>();
            };

            it should_create_the_path_to_the_view_based_on_the_name_of_the_view_class_and_the_application_convention = () =>
            {
                path_requested.should_be_equal_ignoring_case("~/views/MyPage.aspx");
            };

            it should_return_the_page_that_can_display_the_model = () =>
            {
                result.should_be_equal_to(page);
            };

            static IHttpHandler result;
            static IDictionary<Type, Type> list_of_views;
            static ViewForModel<object> page;
            static string path_requested;
        }
    }
}