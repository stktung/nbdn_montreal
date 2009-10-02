using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class BasicCommandRegistry : CommandRegistry
    {
        IEnumerable<ApplicationRequestCommand> all_commands;


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