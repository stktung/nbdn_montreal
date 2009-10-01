namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequestCommand : ApplicationWebCommand
    {
        bool can_handle(ApplicationRequest request);
    }
}