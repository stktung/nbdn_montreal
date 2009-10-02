using System.Collections.Specialized;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class MapperSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Mapper<NameValueCollection, DepartmentItem>,
                                            DepartmentMapper> {}

        [Concern(typeof (DepartmentMapper))]
        public class when_mapping_from_a_name_value_collection_with_the_required_information : concern
        {
            context c = () =>
            {
                payload = new NameValueCollection();
                payload.Add("id", "100");
            };

            because b = () =>
            {
                result = sut.map(payload);
            };


            it should_return_a_department_with_the_correct_id = () =>
            {
                result.id.should_be_equal_to(100);
            };

            static DepartmentItem result;
            static NameValueCollection payload;
        }
    }
}