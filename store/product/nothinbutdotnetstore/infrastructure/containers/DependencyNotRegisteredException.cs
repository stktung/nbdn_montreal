using System;
using System.Runtime.Serialization;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DependencyNotRegisteredException : Exception
    {
        public const string exception_format = "There is no dependency registered for type {0}";

        public DependencyNotRegisteredException(Type type):base(exception_format.format(type.FullName))
        {
            type_that_could_not_be_resolved = type;
        }

        public Type type_that_could_not_be_resolved { get; private set; }
    }
}