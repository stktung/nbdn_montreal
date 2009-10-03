using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface ContainerConfiguration : IDictionary<Type, TypeInstanceResolver>
    {
        void register(Type type, TypeInstanceResolver resolver);
        TypeInstanceResolver create_resolver_for(Func<object> factory);
    }
}