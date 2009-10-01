using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RequestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}