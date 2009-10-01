using System.IO;
using System.Web;

namespace nothinbutdotnetstore.tests.utility
{
    public class ObjectMother
    {
        static public HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static public HttpContext create_http_context(string request_file_name)
        {
            return new HttpContext(create_request(request_file_name), create_response());
        }

        static HttpRequest create_request()
        {
            return create_request("blah.aspx");
        }

        static HttpRequest create_request(string file_name)
        {
            return new HttpRequest(file_name, string.Format("http://server/{0}", file_name), string.Empty);
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }
    }
}