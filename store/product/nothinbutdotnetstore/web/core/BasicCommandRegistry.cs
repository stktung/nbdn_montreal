namespace nothinbutdotnetstore.web.core
{
    public class BasicCommandRegistry : CommandRegistry
    {
        public ApplicationRequestCommand find_command_that_can_process(ApplicationRequest request)
        {
            return new BasicRequestCommand();
        }
    }
}