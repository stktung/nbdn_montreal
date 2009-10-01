namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequestCommand 
    {
        void process(ApplicationRequest request);
        bool can_handle(ApplicationRequest request);
    }
}