using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartApplication
    {
        static public StartupCommandPipe with<T>() where T : StartupCommand
        {
            return new StartupCommandPipe(typeof (T),
                                          new BasicContainerConfiguration());
        }
    }
}