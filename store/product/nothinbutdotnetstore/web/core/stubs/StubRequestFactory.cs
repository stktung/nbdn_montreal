using System;
using System.Collections.Specialized;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public ApplicationRequest create_from(HttpContext http_context)
        {
            return new StubRequest();
        }
        class StubRequest : ApplicationRequest {
            public NameValueCollection Params
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    }
}