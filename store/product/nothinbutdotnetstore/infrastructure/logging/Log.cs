using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        private static LogFactory _log_factory;

        static public Logger bound_to(Type type_that_requires_logging)
        {
            return _log_factory.create_logger_for(type_that_requires_logging);
        }

        static public void initialize_with(LogFactory log_factory)
        {
            _log_factory = log_factory;
        }
    }
}