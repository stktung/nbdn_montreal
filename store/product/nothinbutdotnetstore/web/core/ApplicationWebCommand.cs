namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationWebCommand
    {
        void process(ApplicationRequest request);
    }
}