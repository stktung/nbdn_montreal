using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class BasicTypeInstanceResolver : TypeInstanceResolver
    {
        Func<object> factory;

        public BasicTypeInstanceResolver(Func<object> factory)
        {
            this.factory = factory;
        }

        public object resolve()
        {
            return factory();
        }
    }
}