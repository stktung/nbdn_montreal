using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RequestHandler : IHttpHandler
    {
        FrontController controller;
        RequestFactory factory;

        public RequestHandler(FrontController controller, RequestFactory factory)
        {
            this.controller = controller;
            this.factory = factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            controller.process(factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}