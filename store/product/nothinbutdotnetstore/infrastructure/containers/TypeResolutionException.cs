using System;
using System.Runtime.InteropServices;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class TypeResolutionException : Exception
    {
        public Type type_that_could_not_be_resolved { get; private set; }
    }
}