using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class FakeCommand : ApplicationWebCommand
    {
        public void process(ApplicationRequest request)
        {
                HttpContext.Current.Response.Write("Hello");
        }
    }
}