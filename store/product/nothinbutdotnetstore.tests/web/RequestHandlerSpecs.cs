using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tests.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestHandlerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<IHttpHandler,
                                            RequestHandler> {}

        [Concern(typeof (RequestHandler))]
        public class when_processing_an_http_context : concern
        {
            it should_tell_the_front_controller_to_process_the_incoming_request = () =>
            {
                front_controller.received(controller1 => controller1.process(request));
            };

            because b = () =>
            {
                sut.ProcessRequest(http_context);
            };

            context c = () =>
            {
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<RequestFactory>();

                http_context = ObjectMother.create_http_context();
                request = new object();

                request_factory.Stub(factory => factory.create_from(http_context))
                    .Return(request);
            };

            static FrontController front_controller;
            static object request;
            static HttpContext http_context;
            static RequestFactory request_factory;
        }
    }
}