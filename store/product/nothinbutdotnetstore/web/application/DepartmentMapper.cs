using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentMapper : Mapper<NameValueCollection, DepartmentItem>
    {
        public DepartmentItem map(NameValueCollection item)
        {
            return new DepartmentItem {id = Convert.ToInt64(item["id"])};
        }
    }
}