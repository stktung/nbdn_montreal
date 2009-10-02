using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandPipe
    {
        StartupCommandFactory command_factory;
        Command pipeline;

        public StartupCommandPipe(Type initial_startup_command, StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
            pipeline = command_factory.create_from(initial_startup_command);
        }

        public StartupCommandPipe followed_by<StartupPipelineCommand>() where StartupPipelineCommand : StartupCommand
        {
            pipeline = pipeline.followed_by(command_factory.create_from(typeof(StartupPipelineCommand)));
            return this;
        }

        public void finished_by<StartupCommandType>() where StartupCommandType : StartupCommand
        {
            followed_by<StartupCommandType>();
            pipeline.run();
        }
    }
}