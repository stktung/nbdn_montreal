using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandPipe
    {
        public StartupCommandPipe(Type initial_startup_command, ContainerConfiguration config) {}

        public StartupCommandPipe followed_by<StartupPipelineCommand>() where StartupPipelineCommand : StartupCommand {}

        public void finished_by<T>() where T : StartupCommand {}
    }
}