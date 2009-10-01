using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display<Model>(Model model)
        {
            HttpContext.Current.Items["blah"] = model;
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}