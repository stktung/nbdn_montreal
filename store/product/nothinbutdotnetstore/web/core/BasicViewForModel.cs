using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class BasicViewForModel<Model> : Page,ViewForModel<Model>
    {
        public Model model { get; set; }
    }
}