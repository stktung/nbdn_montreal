using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public ApplicationRequest create_from(HttpContext http_context)
        {
            return new StubRequest(http_context);
        }

        class StubRequest : ApplicationRequest {
            HttpContext http_context;

            public StubRequest(HttpContext http_context)
            {
                this.http_context = http_context;
            }


            public InputModel map<InputModel>()
            {
                return default(InputModel);
            }

            public string raw_url
            {
                get { return http_context.Request.RawUrl; }
            }
        }
    }
}