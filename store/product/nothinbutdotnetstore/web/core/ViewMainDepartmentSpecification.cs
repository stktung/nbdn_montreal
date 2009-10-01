using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartmentSpecification : Specification<ApplicationRequest>
    {
        public bool is_satisfied_by(ApplicationRequest item)
        {
            return item.CommandName == "ViewMainDepartments";
        }
    }
}