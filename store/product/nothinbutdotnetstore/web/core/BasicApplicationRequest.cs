using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public class BasicApplicationRequest : ApplicationRequest
    {
        MapperRegistry mapper_registry;
        string rawUrl;
        NameValueCollection payload;

        public BasicApplicationRequest(MapperRegistry mapper, string raw_url,NameValueCollection payload)
        {
            mapper_registry = mapper;
            rawUrl = raw_url;
            this.payload = payload;
        }

        public InputModel map<InputModel>() 
        {
            return mapper_registry.get_mapper_to_map<NameValueCollection, InputModel>()
                                  .map(payload);
        }

        public string raw_url
        {
            get { return rawUrl; }
        }

    }
}