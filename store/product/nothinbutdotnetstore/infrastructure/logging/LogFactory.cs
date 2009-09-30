using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface LogFactory
    {
        Logger create_logger_for(Type type_that_requires_logging_services);
    }
}