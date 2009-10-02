using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestHasSpecificIdSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Specification<ApplicationRequest>,
                                            RequestHasSpecificId> {}

        [Concern(typeof (RequestHasSpecificId))]
        public class when_request_has_a_matching_id : concern
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument("10");
                request = an<ApplicationRequest>();
                request.Stub(x => x.id).Return("10");
            };

            because b = () =>
            {
                result = sut.is_satisfied_by(request);
            };


            it should_return_true = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static ApplicationRequest request;
            static string id;
        }
    }
}