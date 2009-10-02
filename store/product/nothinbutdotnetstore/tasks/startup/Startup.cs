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
            configure_commands();
            configure_front_controller();
            configure_request_factory();
            configure_service_layer();

        }

        static void configure_request_factory()
        {
            var request_factory_resolver = resolvers.create(() => new BasicRequestFactory());
            config.Add(typeof(RequestFactory), request_factory_resolver);
        }

        static void configure_service_layer()
        {
            catalog_tasks = new StubCatalogTasks();
            view_model_to_views = new Dictionary<Type, Type>();
            response_engine = new BasicResponseEngine(new BasicViewRegistry(view_model_to_views));
        }

        static private void configure_front_controller()
        {
            Container startup_container = new BasicContainer(config);
            IOC.initialize_with(startup_container);

            var front_controller_resolver = resolvers.create(() => new BasicFrontController(new BasicCommandRegistry(list_of_commands)));
            config.Add(typeof(FrontController), front_controller_resolver);
        }

        static void configure_commands()
        {


            list_of_commands.Add(
                       new BasicApplicationRequestCommand(
                           Request.has_a_url_that_contains_the_command<ViewMainDepartments>(),
                           new ViewMainDepartments(catalog_tasks, response_engine)));

            list_of_commands.Add(
                new BasicApplicationRequestCommand(Request.compound_specification(
                                                       Request.has_a_url_that_contains_the_command<ViewProductBrowser>(),
                                                       new DepartmentHasProducts(catalog_tasks)), new ViewProductBrowser(catalog_tasks, response_engine)));

            list_of_commands.Add(
                new BasicApplicationRequestCommand(
                    Request.has_a_url_that_contains_the_command<ViewSubDepartments>(),
                    new ViewSubDepartments(catalog_tasks, response_engine)));

        }

        static ResolverFactory resolvers = new ResolverFactory();
        static IDictionary<Type, TypeInstanceResolver> config = new Dictionary<Type, TypeInstanceResolver>();
        static List<ApplicationRequestCommand> list_of_commands;
        static CatalogTasks catalog_tasks;
        static IDictionary<Type, Type> view_model_to_views;
        static ResponseEngine response_engine;


        public class ResolverFactory
        {
            public TypeInstanceResolver create(Func<object> factory)
            {
                return new BasicTypeInstanceResolver(factory);
            }
        }
    }
}