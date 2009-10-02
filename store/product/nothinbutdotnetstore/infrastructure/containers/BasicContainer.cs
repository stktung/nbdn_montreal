using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class BasicContainer : Container
    {
        IDictionary<Type, Type> types;

        public BasicContainer(IDictionary<Type, Type> types)
        {
            this.types = types;
        }

        public Dependency instance_of<Dependency>()
        {
            ensure_type_is_registered_for<Dependency>();

            return (Dependency) Activator.CreateInstance(types[typeof (Dependency)]);
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