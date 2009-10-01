using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public class RequestHasSpecificCommandName : Specification<ApplicationRequest>
    {
        string expected_command_name;

        public RequestHasSpecificCommandName(string expected_command_name)
        {
            this.expected_command_name = expected_command_name;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return item.command_name == expected_command_name;
        }
    }
}