using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.dsl;

namespace nothinbutdotnetstore.web.core
{
    public class BasicCommandRegistry : CommandRegistry
    {
        IEnumerable<ApplicationRequestCommand> all_commands;

        public BasicCommandRegistry() : this(create_default_commands()) {}

        static IEnumerable<ApplicationRequestCommand> create_default_commands()
        {
            yield return new BasicApplicationRequestCommand(
                Request.has_a_url_that_contains_the_command<ViewMainDepartments>(),
                new ViewMainDepartments());

            yield return new BasicApplicationRequestCommand(
                Request.has_a_url_that_contains_the_command<ViewSubDepartments>(),
                new ViewSubDepartments());
        }

        public BasicCommandRegistry(IEnumerable<ApplicationRequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public ApplicationRequestCommand find_command_that_can_process(ApplicationRequest request)
        {
            return all_commands.FirstOrDefault(command => command.can_handle(request)) ?? new MissingCommand();
        }
    }
}