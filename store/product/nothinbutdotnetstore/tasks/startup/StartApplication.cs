namespace nothinbutdotnetstore.tasks.startup
{
    public class StartApplication
    {
        static public StartupCommandPipe with<StartupCommandType>() where StartupCommandType : StartupCommand
        {
            return new StartupCommandPipe(typeof (StartupCommandType),
                                          new BasicStartupCommandFactory());
        }
    }
}