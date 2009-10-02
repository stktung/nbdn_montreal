using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class BasicApplicationRoutes : ApplicationRoutes
    {
        IList<ApplicationRequestCommand> commands;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ApplicationRequestCommand> GetEnumerator()
        {
            return commands.GetEnumerator();
        }


        public void add_route(Specification<ApplicationRequest> specification, ApplicationWebCommand command)
        {
            commands.Add(new BasicApplicationRequestCommand(specification, command));
        }
    }
}