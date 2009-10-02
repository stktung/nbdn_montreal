using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.dsl;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface Command
    {
        void Execute();
    }

    public interface StartupCommand : Command
    {
        StartupConfiguration configuration { get; set; }
    }

    public class StartupConfiguration
    {
        public ResolverFactory resolvers = new ResolverFactory();
        public IDictionary<Type, TypeInstanceResolver> config = new Dictionary<Type, TypeInstanceResolver>();
        public List<ApplicationRequestCommand> list_of_commands = new List<ApplicationRequestCommand>();
        public IDictionary<Type, Type> view_model_to_views;
        public ResponseEngine response_engine;
        public CatalogTasks catalog_tasks;
    }


    public class ConfigureServiceLayerCommand : StartupCommand
    {
        public void Execute()
        {
            configuration.catalog_tasks = new StubCatalogTasks();
            configuration.view_model_to_views = new Dictionary<Type, Type>();
            configuration.response_engine = new BasicResponseEngine(new BasicViewRegistry(configuration.view_model_to_views));
        }

        public StartupConfiguration configuration { get; set; }
    }

    public class ConfigureCommandsCommand : StartupCommand
    {
        public void Execute()
        {
            configuration.list_of_commands.Add(
                new BasicApplicationRequestCommand(
                    Request.has_a_url_that_contains_the_command<ViewMainDepartments>(),
                    new ViewMainDepartments(configuration.catalog_tasks, configuration.response_engine)));

            configuration.list_of_commands.Add(
                new BasicApplicationRequestCommand(Request.compound_specification(
                                                       Request.has_a_url_that_contains_the_command<ViewProductBrowser>(),
                                                       new DepartmentHasProducts(configuration.catalog_tasks)), new ViewProductBrowser(configuration.catalog_tasks, configuration.response_engine)));

            configuration.list_of_commands.Add(
                new BasicApplicationRequestCommand(
                    Request.has_a_url_that_contains_the_command<ViewSubDepartments>(),
                    new ViewSubDepartments(configuration.catalog_tasks, configuration.response_engine)));
        }

        public StartupConfiguration configuration { get; set; }
    }

    public class ConfigureRequestFactoryCommand : StartupCommand
    {
        public StartupConfiguration configuration { get; set; }

        public void Execute()
        {
            var request_factory_resolver = configuration.resolvers.create(() => new BasicRequestFactory());
            configuration.config.Add(typeof (RequestFactory), request_factory_resolver);
        }
    }

    public class ConfigureFrontController : StartupCommand
    {
        public StartupConfiguration configuration { get; set; }

        public void Execute()
        {
            Container startup_container = new BasicContainer(configuration.config);
            IOC.initialize_with(startup_container);

            var front_controller_resolver = configuration.resolvers.create(() => new BasicFrontController(new BasicCommandRegistry(configuration.list_of_commands)));
            configuration.config.Add(typeof (FrontController), front_controller_resolver);
        }
    }

    public class Startup
    {
        static public void go()
        {
            startby<ConfigureServiceLayerCommand>().followed_by<ConfigureCommandsCommand>().followed_by<ConfigureRequestFactoryCommand>().finished_by<ConfigureFrontController>();
        }

        static StartupCommandPipe startby<T>() where T : StartupCommand, new()
        {
            return new StartupCommandPipe(new T(),new StartupConfiguration());
        }
    }

    public class StartupCommandPipe
    {
        IList<StartupCommand> commands = new List<StartupCommand>();
        StartupConfiguration startup_configuration;

        public StartupCommandPipe(StartupCommand command, StartupConfiguration config)
        {
            startup_configuration = config;
            commands.Add(command);
        }

        public StartupCommandPipe followed_by<T>() where T : StartupCommand, new()
        {
            StartupCommand command = new T();
            commands.Add(command);
            return this;
        }

        public void finished_by<T>() where T : StartupCommand, new()
        {
            StartupCommand command = new T();
            commands.Add(command);

            foreach (var startup_command in commands)
            {
                startup_command.configuration = startup_configuration;
                startup_command.Execute();
            }
        }
    }

    public class ResolverFactory
    {
        public TypeInstanceResolver create(Func<object> factory)
        {
            return new BasicTypeInstanceResolver(factory);
        }
    }
}