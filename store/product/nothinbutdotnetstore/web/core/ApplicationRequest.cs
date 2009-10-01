namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequest
    {
        InputModel map<InputModel>();
        string command_name { get; set; }
    }
}