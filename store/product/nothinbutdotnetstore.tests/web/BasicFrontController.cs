using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class BasicFrontController : FrontController
    {
        CommandRegistry command_registry;

        public BasicFrontController(CommandRegistry command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(ApplicationRequest request)
        {
            command_registry.find_command_that_can_process(request).process(request);
        }
    }
}