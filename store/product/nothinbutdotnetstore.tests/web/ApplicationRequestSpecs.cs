 using System.Collections.Specialized;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ApplicationRequestSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationRequest,
                                             BasicApplicationRequest>
         {
        
         }

         [Concern(typeof(BasicApplicationRequest))]
         public class when_mapping_an_input_model : concern
         {
             context c = () =>
             {
                 number = 42;
                 mapper_registry = the_dependency<MapperRegistry>();
                 mapper = an<Mapper<NameValueCollection, int>>();
                 payload = new NameValueCollection();

                 mapper_registry.Stub(registry => registry.get_mapper_to_map<NameValueCollection, int>())
                     .Return(mapper);

                 mapper.Stub(mapper1 => mapper1.map(payload)).Return(number);

                 provide_a_basic_sut_constructor_argument(string.Empty);
                 provide_a_basic_sut_constructor_argument(payload);
             };

             because b = () =>
             {
                 result = sut.map<int>(); 
             };

        
             it should_return_the_item_mapped_by_the_mapper = () =>
             {
                result.should_be_equal_to(number);
             };

             static int result;
             static int number;
             static MapperRegistry mapper_registry;
             static Mapper<NameValueCollection, int> mapper;
             static NameValueCollection payload;
         }
     }
 }
