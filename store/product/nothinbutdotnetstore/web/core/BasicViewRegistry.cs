using System;
using System.Collections.Generic;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core
{
    public class BasicViewRegistry : ViewRegistry
    {
        IDictionary<Type, Type> view_models_to_views;
        ViewFactory view_factory = (path,type) => BuildManager.CreateInstanceFromVirtualPath(path, type);

        public BasicViewRegistry()
        {
        }

        public BasicViewRegistry(IDictionary<Type, Type> view_models_to_views, ViewFactory view_factory)
        {
            this.view_models_to_views = view_models_to_views;
            this.view_factory = view_factory;
        }

        public ViewForModel<Model> find_view_that_can_process<Model>()
        {
            var view_type = view_models_to_views[typeof (Model)];

            return (ViewForModel<Model>)view_factory(string.Format("~/views/{0}.aspx", view_type.Name),
                                typeof (ViewForModel<Model>));
        }
    }
}