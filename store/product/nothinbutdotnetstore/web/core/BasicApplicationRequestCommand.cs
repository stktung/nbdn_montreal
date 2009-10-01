using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class BasicApplicationRequestCommand : ApplicationRequestCommand
    {
        Specification<ApplicationRequest> request_specification;
        ApplicationWebCommand application_command;

        public BasicApplicationRequestCommand(Specification<ApplicationRequest> request_specification, ApplicationWebCommand application_command)
        {
            this.request_specification = request_specification;
            this.application_command = application_command;
        }

        public void process(ApplicationRequest request)
        {
            application_command.process(request);
        }

        public bool can_handle(ApplicationRequest request)
        {
            return request_specification.is_satisfied_by(request);
        }
    }
}