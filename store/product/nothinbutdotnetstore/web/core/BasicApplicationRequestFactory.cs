using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class BasicApplicationRequestFactory : RequestFactory{
        public ApplicationRequest create_from(HttpContext http_context)
        {
            throw new NotImplementedException();
        }
    }
}