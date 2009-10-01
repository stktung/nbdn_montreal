using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public class BasicApplicationRequest : ApplicationRequest{
        public NameValueCollection Params
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}