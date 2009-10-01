using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public ApplicationRequest create_from(HttpContext http_context)
        {
            if (http_context.Request.RawUrl.Contains("ViewMainDepartments"))
            {
                return new StubRequest("ViewMainDepartments");
            }

            return new StubRequest("NoName");
        }
        class StubRequest : ApplicationRequest {
            
            public StubRequest(string raw_url)
            {
                this.raw_url     = raw_url;
            }


            public InputModel map<InputModel>()
            {
                return default(InputModel);
            }

            public string raw_url
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    }
}