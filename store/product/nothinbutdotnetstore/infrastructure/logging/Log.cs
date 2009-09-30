using System;
using System.Diagnostics;
using System.Text;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        static public LogFactory log_factory { get; set; }

        static public Logger an
        {
            get { return log_factory.create_logger_for(the_type_that_requested_logging()); }
        }

        static Type the_type_that_requested_logging()
        {
            return new StackFrame(2).GetMethod().ReflectedType;
        }
    }
}