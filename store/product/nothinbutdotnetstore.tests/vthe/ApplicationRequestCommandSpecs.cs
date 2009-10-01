 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ApplicationRequestCommandSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationRequestCommand,
                                             ViewDepartmentsCommand>
         {
             protected static ApplicationRequest request;
         }

         [Concern(typeof(ViewDepartmentsCommand))]
         public class when_the_request_can_be_handled_by_the_command : concern
         {
             context c = () =>
                             {
                                 request = new ViewDepartmentsRequest();
                             };

             because b = () =>
                             {
                                result = sut.can_handle(request);
                             };

        
             it can_be_handled_by_the_command = () =>
                        {
                            result.should_be_true();
                        };

             private static bool result;
         }

         [Concern(typeof(ViewDepartmentsCommand))]
         public class when_the_request_can_not_be_handled_by_the_command : concern
         {
             context c = () =>
             {
                 request = an<ApplicationRequest>();

             };

             because b = () =>
             {
                 result = sut.can_handle(request);
             };


             it can_not_be_handled_by_the_command = () =>
             {
                 result.should_be_false();
             };

             private static bool result;
         }

         [Concern(typeof (ViewDepartmentsCommand))]
         public class when_the_command_is_processed : concern
         {
             private context c = () =>
                                     {

                                     };

             private because b = () =>
                                     {

                                     };


             private it first_observation = () =>
                                {
                                    

                                };
         }
     }
 }
