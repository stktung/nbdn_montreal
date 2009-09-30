using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.logging;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class LogSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Log))]
        public class when_providing_access_to_a_logging_adapter : concern
        {
            it should_provide_access_to_the_logging_framework_that_it_was_initialized_with = () =>
            {
                result.should_be_equal_to(logger);
            };

            because b = () =>
            {
                result = Log.an;
            };

            context c = () =>
            {
                logger = an<Logger>();
                log_factory = an<LogFactory>();

                log_factory.Stub(x => x.create_logger_for(typeof(when_providing_access_to_a_logging_adapter)))
                    .Return(logger);

                change(() => Log.log_factory).to(log_factory);
            };


            static Logger result;
            static Logger logger;
            static LogFactory log_factory;
        }
    }
}