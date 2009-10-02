using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static public void go()
        {

            ResolverFactory resolvers = new ResolverFactory();

            IDictionary<Type, TypeInstanceResolver> config = new Dictionary<Type, TypeInstanceResolver>();

            IEnumerable<ApplicationRequestCommand> commands = new List<ApplicationRequestCommand>();

            TypeInstanceResolver front_controller_resolver = resolvers.create(() =>
                                                             new BasicFrontController(new BasicCommandRegistry(commands)));
            TypeInstanceResolver request_factory_resolver = resolvers.create(() => new BasicRequestFactory());
           
            config.Add(typeof(RequestFactory), request_factory_resolver);
            config.Add(typeof(FrontController), front_controller_resolver); 
            
            Container startup_container = new BasicContainer(config);
            IOC.initialize_with(startup_container);
        }
    }

    public class ResolverFactory
    {
        public BasicTypeInstanceResolver create(Func<object> factory) { 
            return new BasicTypeInstanceResolver(factory);
        }
    }
}