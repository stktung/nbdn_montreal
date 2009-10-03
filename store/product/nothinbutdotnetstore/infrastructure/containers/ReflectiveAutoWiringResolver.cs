using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class ReflectiveAutoWiringResolver : TypeInstanceResolver
    {
        Type type;

        public ReflectiveAutoWiringResolver(Type type)
        {
            this.type = type;
        }

        public object resolve()
        {
            var constructor = type.GetConstructors()[0];
            var parameter_infos = constructor.GetParameters();

            var parameters = new List<object>();

            foreach (var parameter_info in parameter_infos)
            {
                parameters.Add(IOC.resolve.instance_of(parameter_info.ParameterType));
            }

            return constructor.Invoke(parameters.ToArray());
        }
    }
}