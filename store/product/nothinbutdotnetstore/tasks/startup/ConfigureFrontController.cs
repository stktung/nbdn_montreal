using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        ContainerConfiguration container_configuration;

        public ConfigureFrontController(ContainerConfiguration container_configuration)
        {
            this.container_configuration = container_configuration;
        }

        public void run()
        {
            var routes = new BasicApplicationRoutes();

            var view_model_registration = new BasicViewToViewModelRegistration();

            container_configuration.register(typeof (ApplicationRoutes),
                                             container_configuration.create_resolver_for(() => routes));

            container_configuration.register(typeof(CommandRegistry),
                container_configuration.create_resolver_for(() => new BasicCommandRegistry(routes)));

            container_configuration.register(typeof(FrontController),
                container_configuration.create_resolver_for(() => new BasicFrontController(IOC.resolve.instance_of<CommandRegistry>())));

            container_configuration.register(typeof(RequestFactory),
                container_configuration.create_resolver_for(() => new BasicRequestFactory()));

            container_configuration.register(typeof(ResponseEngine),
                container_configuration.create_resolver_for(() => new BasicResponseEngine()));

            container_configuration.register(typeof(IDictionary<Type,Type>),
                container_configuration.create_resolver_for(() => view_model_registration));

            container_configuration.register(typeof(ViewToViewModelRegistration),
                container_configuration.create_resolver_for(() => view_model_registration));
        }
    }
}