namespace nothinbutdotnetstore.web.core
{
    public class BasicFrontController : FrontController
    {
        CommandRegistry command_registry;
        public BasicFrontController() : this(new BasicCommandRegistry())
        {
        }

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