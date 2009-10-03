using System;
using System.Linq;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandConvention : Specification<Type>
    {
        public bool is_satisfied_by(Type item)
        {
            var constructor_info = item.GetConstructors().First();

            return typeof (StartupCommand).IsAssignableFrom(item)
                   && !item.IsAbstract
                   && item.IsClass
                   && constructor_info != null
                   && constructor_info.GetParameters().Count() == 1
                   && constructor_info.GetParameters().First().ParameterType == typeof (ContainerConfiguration);
        }
    }
}