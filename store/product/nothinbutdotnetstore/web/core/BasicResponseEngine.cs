using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class BasicResponseEngine : ResponseEngine
    {
        ViewRegistry view_registry;

        public BasicResponseEngine() : this(new BasicViewRegistry()) { }

        public BasicResponseEngine(ViewRegistry view_registry)
        {
            this.view_registry = view_registry;
        }

        public void display<Model>(Model model)
        {
            HttpContext.Current.Server.Transfer(view_registry.find_view_that_can_process<Model>(), false);
        }
    }
}