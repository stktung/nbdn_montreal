using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class BasicContainer : Container
    {
        IDictionary<Type, TypeInstanceResolver> types;

        public BasicContainer(IDictionary<Type, TypeInstanceResolver> types)
        {
            this.types = types;
        }

        public Dependency instance_of<Dependency>()
        {
            return (Dependency) instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            ensure_resolver_is_registered_for(dependency_type);
            try
            {
                return types[dependency_type].resolve();
            }
            catch (Exception exception) {
                throw new TypeResolutionException(dependency_type, exception);
            }
        }

        void ensure_resolver_is_registered_for(Type dependency_type)
        {
            if (!types.ContainsKey(dependency_type))
                throw new DependencyNotRegisteredException(dependency_type);
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}