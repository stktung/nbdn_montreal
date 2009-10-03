using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class BasicViewToViewModelRegistration : Dictionary<Type,Type> , ViewToViewModelRegistration
    {
        public void add<ModelType, ViewType>()
        {
            base.Add(typeof(ModelType),typeof(ViewType));
        }
    }
}