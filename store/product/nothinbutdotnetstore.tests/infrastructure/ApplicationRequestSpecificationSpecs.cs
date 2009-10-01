using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ApplicationRequestSpecificationSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Specification<ApplicationRequest>,
                                            RequestHasSpecificFileName>
        {
            protected static bool result;
            protected static ApplicationRequest request;
        }

        [Concern(typeof (RequestHasSpecificFileName))]
        public class when_determining_whether_it_is_satisfied_by_a_request : concern
        {
            context c = () =>
            {
                file_name = "theExpectedFileName";
                provide_a_basic_sut_constructor_argument(file_name);
                request = an<ApplicationRequest>();
            };


            it should_not_be_satisfied_if_the_file_name_does_not_match = () =>
            {
                request.Stub(x => x.raw_url).Return("http://mywebserver/theWrongFileName");
                sut.is_satisfied_by(request).should_be_false();
            };

            it should_be_satisfied_if_the_request_contains_the_expected_file_name = () =>
            {
                request.Stub(x => x.raw_url).Return("http://mywebserver/theExpectedFileName");
                sut.is_satisfied_by(request).should_be_true();
            };

            static string file_name;
        }
    }
}