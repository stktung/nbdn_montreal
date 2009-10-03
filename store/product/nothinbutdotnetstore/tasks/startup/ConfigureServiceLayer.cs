using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        ContainerConfiguration container_configuration;
        public ConfigureServiceLayer(ContainerConfiguration container_configuration)
        {
            this.container_configuration = container_configuration;
        }

        public void run()
        {
            container_configuration.register(typeof(CatalogTasks),
                                new BasicTypeInstanceResolver(() => new StubCatalogTasks()));
        }
    }
}