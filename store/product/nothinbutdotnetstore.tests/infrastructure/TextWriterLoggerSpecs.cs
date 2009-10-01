using System.IO;
 using System.Text;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class TextWriterLoggerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Logger,
                                             TextWriterLogger>
         {
        
         }

         [Concern(typeof(TextWriterLogger))]
         public class when_logging_an_informational_message : concern
         {
             it should_write_the_message_to_its_text_writer = () =>
             {
                message.ToString().should_be_equal_ignoring_case("This is cool\r\n");
             };

             because b = () =>
             {
                sut.informational("This is cool"); 
             };

             context c = () =>
             {
                message = new StringBuilder(); 
                provide_a_basic_sut_constructor_argument<TextWriter>(new StringWriter(message));
             };


             static StringBuilder message;
         }
     }
 }
