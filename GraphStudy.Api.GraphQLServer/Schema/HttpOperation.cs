using System.Threading.Tasks;
using System.Net.Http;

namespace GraphStudy.Api.GraphQLServer.Schema
{
    public class HttpOperation
    {
        private IHttpClientFactory httpClientFactory;

        private readonly HttpClient httpClient;

        public HttpOperation(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpClient = this.httpClientFactory.CreateClient();
        }

        public async Task<string> GetResponseContent(string URL)
        {
            var response = await httpClient.GetStringAsync(URL);
            return response;
        }
    }
}