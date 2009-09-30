 using System;
 using System.IO;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class LogFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<LoggerFactory,TextWriterLoggerFactory>
         {
        
         }

         [Concern(typeof(TextWriterLoggerFactory))]
         public class when_it_creates_a_logger : concern
         {
             because b = () =>
             {
                 logger = sut.create_log_bound_to(typeof (when_it_creates_a_logger));
             };

        
             it should_return_a_text_writer_logger = () =>
             {
                 logger.should_be_an<TextWriterLogger>();
             };

             static Logger logger;
         }
     }

     public class TextWriterLoggerFactory: LoggerFactory {
         public Logger create_log_bound_to(Type type)
         {
             return new TextWriterLogger(new StringWriter());
         }
     }
 }
