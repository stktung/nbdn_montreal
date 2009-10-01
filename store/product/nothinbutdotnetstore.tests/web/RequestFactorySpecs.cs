 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tests.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<RequestFactory,
                                             BasicRequestFactory>
         {
        
         }

         [Concern(typeof(BasicRequestFactory))]
         public class when_the_request_factory_is_creating_an_application_request : concern
         {
             context c = () =>
             {
                 factory = an<RequestFactory>();
                 http_context = ObjectMother.create_http_context("ViewMainDepartments.store");
             };

             because b = () =>
             {
                 request = factory.create_from(http_context);
             };

             it should_create_an_application_request_with_a_command_name_based_on_the_string_preceding_the_store_extension_in_the_url_of_the_http_request = () =>
             {
                 request.command_name.should_be_equal_to("ViewMainDepartment");
             };

             static RequestFactory factory;
             static HttpContext http_context;
             static ApplicationRequest request;
         }
     }
 }
