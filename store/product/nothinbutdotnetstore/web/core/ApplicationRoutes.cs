using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationRoutes : IEnumerable<ApplicationRequestCommand>
    {
        void add_route(Specification<ApplicationRequest> specification,ApplicationWebCommand command);
    }
}