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
    public class Startup
    {
        static public void go()
        {
            configure_front_controller();
            configure_service_layer();
            configure_commands();
        }

        static private void configure_front_controller() {
            var resolvers = new ResolverFactory();
            var config = new Dictionary<Type, TypeInstanceResolver>();
            Container startup_container = new BasicContainer(config);
            IOC.initialize_with(startup_container);

            var commands = configure_commands();

            var front_controller_resolver = resolvers.create(() => new BasicFrontController(new BasicCommandRegistry(commands)));
            var request_factory_resolver = resolvers.create(() => new BasicRequestFactory());

            config.Add(typeof (RequestFactory), request_factory_resolver);
            config.Add(typeof (FrontController), front_controller_resolver);
        }

        static List<ApplicationRequestCommand> configure_commands()
        {
            var catalog_tasks = new StubCatalogTasks();
            var view_model_to_views = new Dictionary<Type, Type>();
            var response_engine = new BasicResponseEngine(new BasicViewRegistry(view_model_to_views));

            return new List<ApplicationRequestCommand>
                   {
                       new BasicApplicationRequestCommand(
                           Request.has_a_url_that_contains_the_command<ViewMainDepartments>(),
                           new ViewMainDepartments(catalog_tasks, response_engine)),
                       new BasicApplicationRequestCommand(Request.compound_specification(
                                                              Request.has_a_url_that_contains_the_command<ViewProductBrowser>(),
                                                              new DepartmentHasProducts(catalog_tasks)), new ViewProductBrowser(catalog_tasks, response_engine)),
                       new BasicApplicationRequestCommand(
                           Request.has_a_url_that_contains_the_command<ViewSubDepartments>(),
                           new ViewSubDepartments(catalog_tasks, response_engine))
                   };
        }

        public class ResolverFactory
        {
            public TypeInstanceResolver create(Func<object> factory)
            {
                return new BasicTypeInstanceResolver(factory);
            }
        }
    }