using System;
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
            public InputModel map<InputModel>()
            {
                throw new NotImplementedException();
            }

            public string command_name
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    }
}