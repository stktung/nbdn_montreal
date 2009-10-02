using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.dsl;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static public void go()
        {
            var config = new Dictionary<Type, TypeInstanceResolver>();
            Container startup_container = new BasicContainer(config);
            IOC.initialize_with(startup_container);

            var resolvers = new ResolverFactory();
            var commands = new List<ApplicationRequestCommand>();
            var front_controller_resolver = resolvers.create(() => new BasicFrontController(new BasicCommandRegistry(commands)));
            var request_factory_resolver = resolvers.create(() => new BasicRequestFactory());

            commands.Add(new BasicApplicationRequestCommand(
                Request.has_a_url_that_contains_the_command<ViewMainDepartments>(),
                new ViewMainDepartments()));
           
            config.Add(typeof(RequestFactory), request_factory_resolver);
            config.Add(typeof(FrontController), front_controller_resolver); 
            
        }
    }

    public class ResolverFactory
    {
        public TypeInstanceResolver create(Func<object> factory) { 
            return new BasicTypeInstanceResolver(factory);
        }
    }
}