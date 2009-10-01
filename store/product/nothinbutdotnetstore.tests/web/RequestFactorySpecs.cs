using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RequestFactory,
                                            BasicApplicationRequestFactory> {}

        [Concern(typeof (BasicApplicationRequestFactory))]
        public class when_factory_creates_the_request : concern
        {
            context c = () =>
            {
                http_context = the_dependency<HttpContext>();
            };

            because b = () =>
            {
                request = sut.create_from(http_context);
            };


            it should_put_the_params_from_the_http_request_into_the_application_request = () => {
                request.Params.should_be_equal_to(http_context.Request.Params);
            };

            static HttpContext http_context;
            static ApplicationRequest request;
        }
    }
}