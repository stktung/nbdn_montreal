namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequest
    {
        InputModel map<InputModel>();
        string raw_url { get; }
    }
}
