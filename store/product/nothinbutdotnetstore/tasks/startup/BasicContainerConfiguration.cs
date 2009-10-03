using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class BasicContainerConfiguration : Dictionary<Type, TypeInstanceResolver>, ContainerConfiguration
    {
        public void register(Type type, TypeInstanceResolver resolver)
        {
            base.Add(type, resolver);
        }

        public TypeInstanceResolver create_resolver_for(Func<object> factory)
        {
            return new BasicTypeInstanceResolver(factory); 
        }
    }
}