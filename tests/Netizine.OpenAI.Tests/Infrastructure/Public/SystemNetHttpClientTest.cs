namespace OpenAI.Tests
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Moq.Protected;
    using Newtonsoft.Json.Linq;
    using OpenAI;
    using Xunit;

    public class SystemNetHttpClientTest : BaseOpenAITest
    {
        public SystemNetHttpClientTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
        }

        [Fact]
        public async Task MakeRequestAsync()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = new StringContent("Hello world!");
            MockHttpClientFixture.MockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(responseMessage));
            var client = new SystemNetHttpClient(
                new HttpClient(MockHttpClientFixture.MockHandler.Object));
            var request = new OpenAIRequest(
                OpenAIClient,
                HttpMethod.Post,
                "/foo",
                null,
                null);

            var response = await client.MakeRequestAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Hello world!", response.Content);
        }

        [Fact]
        public void CanInspectMaxNetworkRetries()
        {
            var client = new SystemNetHttpClient(
                httpClient: new HttpClient(MockHttpClientFixture.MockHandler.Object),
                maxNetworkRetries: 2);

            Assert.Equal(2, client.MaxNetworkRetries);
        }
    }
}
