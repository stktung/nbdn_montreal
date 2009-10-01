using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRequest
    {
        NameValueCollection Params { get; set; }
    }
}