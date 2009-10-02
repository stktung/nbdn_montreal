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
            return (Dependency) instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            object obj;
            if (types.TryGetValue(dependency_type, out obj))
            {
                return obj;
            }

            return null;
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }

    }
}