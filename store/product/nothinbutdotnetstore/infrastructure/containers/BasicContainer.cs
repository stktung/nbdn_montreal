using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class BasicContainer : Container
    {
        IDictionary<Type, object> types;

        public BasicContainer(IDictionary<Type, object> types)
        {
            this.types = types;
        }

        public Dependency instance_of<Dependency>()
        {
            ensure_type_is_registered_for<Dependency>();

            return (Dependency) types[typeof (Dependency)];
        }

        public object instance_of(Type dependency_type)
        {
            throw new NotImplementedException();
        }

        void ensure_type_is_registered_for<Dependency>()
        {
            if (!types.ContainsKey(typeof (Dependency)))
                throw new DependencyNotRegisteredException(typeof (Dependency));
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}