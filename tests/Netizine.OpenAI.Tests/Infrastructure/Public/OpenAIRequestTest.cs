namespace OpenAI.Tests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using OpenAI;
    using OpenAI.Tests.Infrastructure.TestData;
    using Xunit;

    public class OpenAIRequestTest : BaseOpenAITest
    {
        private readonly IOpenAIClient openAIClient;

        public OpenAIRequestTest()
        {
            this.openAIClient = new OpenAIClient(
                "sk-test", null,
                apiBase: "https://client.example.com");
        }

        [Fact]
        public void Ctor_GetRequest()
        {
            var request = new OpenAIRequest(
                this.openAIClient,
                HttpMethod.Get,
                "/get",
                new TestOptions { String = "string!" },
                new RequestOptions());

            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal($"{this.openAIClient.ApiBase}/get?string=string!", request.Uri.ToString());
            Assert.Equal(
                $"Bearer {this.openAIClient.ApiKey}",
                request.AuthorizationHeader.ToString());
            Assert.False(request.OpenAIHeaders.ContainsKey("OpenAI-Organization"));
            Assert.Null(request.Content);
        }

        [Fact]
        public async Task Ctor_PostRequest()
        {
            var request = new OpenAIRequest(
                this.openAIClient,
                HttpMethod.Post,
                "/v1/edits",
                new TestOptions { String = "{\r\n  \"model\": \"text-davinci-edit-001\",\r\n  \"input\": \"What day of the wek is it?\",\r\n  \"instruction\": \"Fix the spelling mistakes.\",\r\n  \"n\": 1,\r\n  \"temperature\": 1,\r\n  \"top_p\": 1\r\n}" },
                new RequestOptions());

            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal($"{this.openAIClient.ApiBase}/v1/edits", request.Uri.ToString());
            Assert.Equal(
                $"Bearer {this.openAIClient.ApiKey}",
                request.AuthorizationHeader.ToString());
            Assert.NotNull(request.Content);
            var content = await request.Content.ReadAsStringAsync();
            Assert.Equal("string=%7B%0D%0A++%22model%22%3A+%22text-davinci-edit-001%22%2C%0D%0A++%22input%22%3A+%22What+day+of+the+wek+is+it%3F%22%2C%0D%0A++%22instruction%22%3A+%22Fix+the+spelling+mistakes.%22%2C%0D%0A++%22n%22%3A+1%2C%0D%0A++%22temperature%22%3A+1%2C%0D%0A++%22top_p%22%3A+1%0D%0A%7D", content);
        }

        [Fact]
        public void Ctor_DeleteRequest()
        {
            var request = new OpenAIRequest(
                this.openAIClient,
                HttpMethod.Delete,
                "/delete",
                new TestOptions { String = "string!" },
                new RequestOptions());

            Assert.Equal(HttpMethod.Delete, request.Method);
            Assert.Equal(
                $"{this.openAIClient.ApiBase}/delete?string=string!",
                request.Uri.ToString());
            Assert.Equal(
                $"Bearer {this.openAIClient.ApiKey}",
                request.AuthorizationHeader.ToString());
            Assert.False(request.OpenAIHeaders.ContainsKey("OpenAI-Organization"));
            Assert.Null(request.Content);
        }

        [Fact]
        public void Ctor_RequestOptions()
        {
            var client = new OpenAIClient("sk-test");
            var requestOptions = new RequestOptions
            {
                ApiKey = "sk_override",
                OrganizationId = "organization_id",
                BaseUrl = "https://override.example.com"
            };
            var request = new OpenAIRequest(
                this.openAIClient,
                HttpMethod.Get,
                "/v1/engines",
                null,
                requestOptions);

            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal($"{requestOptions.BaseUrl}/v1/engines", request.Uri.ToString());
            Assert.Equal($"Bearer {requestOptions.ApiKey}", request.AuthorizationHeader.ToString());
            Assert.True(request.OpenAIHeaders.ContainsKey("OpenAI-Organization"));
            Assert.Equal("organization_id", request.OpenAIHeaders["OpenAI-Organization"]);
            Assert.Null(request.Content);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyIsNull()
        {
            var client = new OpenAIClient(null);
            var requestOptions = new RequestOptions();

            var exception = Assert.Throws<OpenAIException>(() =>
                new OpenAIRequest(client, HttpMethod.Get, "/get", null, requestOptions));

            Assert.Contains("No API key provided.", exception.Message);
        }
    }
}
