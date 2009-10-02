using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.web.core
{
    public class BasicViewRegistry : ViewRegistry
    {
        IEnumerable<KeyValuePair<Type, IHttpHandler>> list_of_views;

        public BasicViewRegistry() : this(create_default_list_of_views()) {}

        static IEnumerable<KeyValuePair<Type, IHttpHandler>> create_default_list_of_views()
        {
            yield return new KeyValuePair<Type, IHttpHandler>(typeof(IEnumerable<DepartmentItem>), BuildManager.CreateInstanceFromVirtualPath("~/views/DepartmentBrowser.aspx", typeof (Page)) as Page);
            yield return new KeyValuePair<Type, IHttpHandler>(typeof(IEnumerable<ProductItem>), BuildManager.CreateInstanceFromVirtualPath("~/views/ProductBrowser.aspx", typeof(IHttpHandler)) as IHttpHandler);
        }

        public BasicViewRegistry(IEnumerable<KeyValuePair<Type, IHttpHandler>> list_of_views)
        {
            this.list_of_views = list_of_views;
        }

        public IHttpHandler find_view_that_can_process<Model>()
        {
            var list = new List<KeyValuePair<Type, IHttpHandler>>(list_of_views);
            return list.First(pair => pair.Key.Equals(typeof (Model))).Value;
        }
    }
}