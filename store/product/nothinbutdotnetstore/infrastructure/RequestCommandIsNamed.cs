using System;
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
            var url_segments = item.raw_url.Split(new[] {'/'});

            foreach (var url_segment in url_segments)
            {
                if (expected_file_name.Equals(url_segment, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}