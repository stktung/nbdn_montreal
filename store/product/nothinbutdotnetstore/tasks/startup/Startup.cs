namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static public void go()
        {
            StartApplication.with<ConfigurationContainer>()
                .followed_by<ConfigureServiceLayer>()
                .followed_by<ConfigureFrontController>()
                .followed_by<ConfigureApplicationCommands>()
                .finished_by<ConfigureRequestToCommandRouting>();
        }

    }
}