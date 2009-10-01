using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public class CommandNameSpecification : Specification<ApplicationRequest>
    {
        string command_name;

        public CommandNameSpecification(string command_name)
        {
            this.command_name = command_name;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return item.command_name == command_name;
        }
    }
}