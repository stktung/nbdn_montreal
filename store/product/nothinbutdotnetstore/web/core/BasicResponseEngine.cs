using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class BasicResponseEngine : ResponseEngine
    {
        static public TransferAction transfer_action = (handler, preserve) => HttpContext.Current.Server.Transfer(handler, preserve);
        ViewRegistry view_registry;

        public BasicResponseEngine() {}

        public BasicResponseEngine(ViewRegistry view_registry)
        {
            this.view_registry = view_registry;
        }

        public void display<Model>(Model model)
        {
            var page = (ViewForModel<Model>)view_registry.find_view_that_can_process<Model>();
            page.model = model;
            transfer_action(page, true);
        }
    }
}