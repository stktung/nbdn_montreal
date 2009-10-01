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
            public string command_name { get; set; }

            public StubRequest(string name)
            {
                this.command_name = name; 
            }


            public InputModel map<InputModel>()
            {
                return default(InputModel);
            }
        }
    }
}