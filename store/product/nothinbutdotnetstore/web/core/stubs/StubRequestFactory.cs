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
             string name;

            public StubRequest(string name)
            {
                this.name = name; 
            }


            public InputModel map<InputModel>()
            {
                return default(InputModel);
            }

            public string CommandName
            {
                get { return name; }
                set { name = value; }
            }
        }
    }
}