using System;

namespace nothinbutdotnetstore.web.core
{
    public class MissingCommand : ApplicationRequestCommand
    {
        public void process(ApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(ApplicationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}