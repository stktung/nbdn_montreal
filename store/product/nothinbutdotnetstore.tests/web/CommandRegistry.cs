using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public interface CommandRegistry
    {
        void Lookup(ApplicationRequest request);
    }
}