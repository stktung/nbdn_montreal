using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupCommandFactory
    {
        StartupCommand create_from(Type type);
    }
}