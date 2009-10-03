using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewToViewModelRegistration : IDictionary<Type,Type>
    {
        void add<ModelType, ViewType>();
    }
}