using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class TypeResolutionException : Exception
    {
        public TypeResolutionException(Type type, Exception exception) : base("", exception)
        {
            type_that_could_not_be_resolved = type;
        }


        public Type type_that_could_not_be_resolved { get; private set; }
    }
}