using System;

namespace nothinbutdotnetstore.web.core
{
    public class ViewDepartmentsCommand : ApplicationRequestCommand
    {
        public void process(ApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(ApplicationRequest request)
        {
            return request is ViewDepartmentsRequest ? true : false;
        }
    }
}