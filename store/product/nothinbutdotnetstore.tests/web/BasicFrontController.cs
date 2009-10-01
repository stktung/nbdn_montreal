using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class BasicFrontController : FrontController
    {
        readonly CommandRegistry command_registry;

        public BasicFrontController(CommandRegistry command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(ApplicationRequest request)
        {
            command_registry.Lookup(request);
        }
    }
}