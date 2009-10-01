namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequest
    {
        InputModel map<InputModel>();
        string CommandName { get; set; }
    }
}