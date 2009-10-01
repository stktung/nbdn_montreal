 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class CommandRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                             BasicCommandRegistry>
         {
        
         }

         [Concern(typeof(BasicCommandRegistry))]
         public class when_processing_a_lookup : concern
         {
             context c = () =>
                             {
                                 request = an<ApplicationRequest>();
                             };

             because b = () =>
                             {
                                 result = sut.find_command_that_can_process(request);
                             };

        
             it should_return_a_command = () =>
                        {
                            result.should_be_an_instance_of<ApplicationRequestCommand>();
                        };

             private static ApplicationRequest request;
             private static ApplicationRequestCommand result;
         }
     }
 }
