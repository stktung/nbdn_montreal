using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class ApplicationRequestSpecifications {
        public static Specification<ApplicationRequest> has_a_command_name_equal_to(string command)
        {
            return new RequestHasSpecificCommandName(command);
        }
    }
}