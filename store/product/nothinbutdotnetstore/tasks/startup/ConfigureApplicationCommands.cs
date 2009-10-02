using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationCommands : StartupCommand
    {
        ContainerConfiguration configuration;

        public ConfigureApplicationCommands(ContainerConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void run()
        {
            configuration.register(typeof (ViewMainDepartments),
                                   configuration.create_resolver_for(() => new ViewMainDepartments(
                                                                               IOC.resolve.instance_of<CatalogTasks>(),
                                                                               IOC.resolve.instance_of<ResponseEngine>())));

            configuration.register(typeof (ViewSubDepartments),
                                   configuration.create_resolver_for(() => new ViewSubDepartments(
                                                                               IOC.resolve.instance_of<CatalogTasks>(),
                                                                               IOC.resolve.instance_of<ResponseEngine>())));

            configuration.register(typeof (ViewProductBrowser),
                                   configuration.create_resolver_for(() => new ViewProductBrowser(
                                                                               IOC.resolve.instance_of<CatalogTasks>(),
                                                                               IOC.resolve.instance_of<ResponseEngine>())));
        }
    }
}