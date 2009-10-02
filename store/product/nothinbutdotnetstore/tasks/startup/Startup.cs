namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static public void go()
        {
            StartApplication.with<ConfigurationContainer>()
                .followed_by<ConfigureServiceLayer>()
                .followed_by<ConfigureFrontController>()
                .finished_by<ConfigureRequestToCommandRouting>();
        }

    }
}