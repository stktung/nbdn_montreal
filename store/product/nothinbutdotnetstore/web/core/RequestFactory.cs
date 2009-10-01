using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestFactory
    {
        ApplicationRequest create_from(HttpContext http_context);
    }
}