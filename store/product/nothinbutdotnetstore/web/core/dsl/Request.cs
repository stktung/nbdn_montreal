using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.dsl
{
    public class Request
    {
        static public Specification<ApplicationRequest> compound_specification(params Specification<ApplicationRequest>[] specs)
        {
            return new CompoundSpecification<ApplicationRequest>(specs);
        }
        
        static public Specification<ApplicationRequest> has_a_url_that_contains_the_command<Command>() where Command : ApplicationWebCommand
        {
            return new RequestHasSpecificFileName(typeof(Command).Name);
        }
    }
}