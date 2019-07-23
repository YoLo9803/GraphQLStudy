using System.Threading.Tasks;
using System.Net.Http;

namespace GraphStudy.SearchFriendsWebServer.Services
{
    public class HttpOperation
    {
        IHttpClientFactory httpClientFactory;
        public HttpOperation(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
    }
}