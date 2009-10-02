using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigurationContainer : StartupCommand
    {
        ContainerConfiguration container_configuration;

        public ConfigurationContainer(ContainerConfiguration container_configuration)
        {
            this.container_configuration = container_configuration;
        }

        public void run()
        {
            Container startup_container = new BasicContainer(container_configuration);
            IOC.initialize_with(startup_container);
        }
    }
}