namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequestCommand 
    {
        void process(ApplicationRequest some_request);
    }
}