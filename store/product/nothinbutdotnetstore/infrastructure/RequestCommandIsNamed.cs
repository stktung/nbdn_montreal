using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public class RequestHasSpecificFileName : Specification<ApplicationRequest>
    {
        string expected_file_name;

        public RequestHasSpecificFileName(string expected_file_name)
        {
            this.expected_file_name = expected_file_name;
        }

        public bool is_satisfied_by(ApplicationRequest item)
        {
            return item.raw_url.Contains(expected_file_name);
        }
    }
}