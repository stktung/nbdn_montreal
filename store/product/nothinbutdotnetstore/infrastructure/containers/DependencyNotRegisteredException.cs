using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DependencyNotRegisteredException : Exception
    {
        public DependencyNotRegisteredException(Type type)
        {
            type_that_could_not_be_resolved = type;
        }

        public Type type_that_could_not_be_resolved { get; private set; }
    }
}