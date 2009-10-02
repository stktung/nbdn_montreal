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

        [Concern(typeof (BasicViewRegistry))]
        public class when_getting_a_view_for_a_model_and_it_has_the_view : concern
        {
            context c = () =>
            {
                list_of_views = new List<KeyValuePair<Type, IHttpHandler>>();
                page = an<IHttpHandler>();

                list_of_views.Add(new KeyValuePair<Type, IHttpHandler>(typeof(object), page));
                provide_a_basic_sut_constructor_argument<IEnumerable<KeyValuePair<Type, IHttpHandler>>>(list_of_views);
            };

            because b = () =>
            {
                result = sut.find_view_that_can_process<object>();
            };

            it should_return_a_view = () =>
            {
                result.should_be_equal_to(page);
            };

            static IHttpHandler result;
            static IList<KeyValuePair<Type, IHttpHandler>> list_of_views;
            static IHttpHandler page;
        }
    }
}