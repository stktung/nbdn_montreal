using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        IHttpHandler find_view_that_can_process<Model>();
    }
}