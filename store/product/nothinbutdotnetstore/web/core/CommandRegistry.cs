namespace nothinbutdotnetstore.web.core
{
    public interface CommandRegistry
    {
        ApplicationRequestCommand find_command_that_can_process(ApplicationRequest request);
    }
}