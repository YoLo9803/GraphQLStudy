using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace GraphStudy.Api.GraphQLServer.Tests
{
    public class BasicTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/graphql")]
        public async Task GetEndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json", 
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData(1)]
        public async Task GetQueryUserByIdRequest(int id)
        {
            //Arrange
            var client = _factory.CreateClient();
            string requestURL = string.Format("/graphql?query={{user(id:{0}){{id,name}}}}",id);

            //Act
            var response = await client.GetStringAsync(requestURL);

            //Assert
            Assert.Equal("{\"data\":{\"user\":{\"id\":1,\"name\":\"chris\"}}}",response);
        }
    }
}