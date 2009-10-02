using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public delegate void TransferAction(IHttpHandler handler, bool preserve);
}