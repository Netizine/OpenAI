#pragma warning disable CS0618
namespace OpenAI.Tests
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenAI;
    using Xunit;

    public class OpenAIClientTest : BaseOpenAITest
    {
        private readonly DummyHttpClient httpClient;
        private readonly OpenAIClient openAIClient;
#pragma warning disable CS0649
        private readonly BaseOptions options;
#pragma warning restore CS0649
        private readonly RequestOptions requestOptions;

        public OpenAIClientTest()
        {
            this.httpClient = new DummyHttpClient();
            this.openAIClient = new OpenAIClient(
                "sk-test",
                httpClient: this.httpClient);

            // James

            // this.options = new ChargeCreateOptions
            // {
            //     Amount = 123,
            //     Currency = "usd",
            //     Source = "tok_visa",
            // };
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Ctor_DoesNotThrowsIfApiKeyIsNull()
        {
            var client = new OpenAIClient(null);
            Assert.NotNull(client);
            Assert.Null(client.ApiKey);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => new OpenAIClient(string.Empty));
            Assert.Contains("API key cannot be the empty string.", exception.Message);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyContainsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() => new OpenAIClient("sk-test\n"));
            Assert.Contains("API key cannot contain whitespace.", exception.Message);
        }

        [Fact]
        public async Task RequestAsync_OkResponse()
        {
            var response = new OpenAIResponse(HttpStatusCode.OK, null, "{\n  \"id\": \"text-davinci-003\",\n  \"object\": \"engine\",\n  \"owner\": \"openai\",\n  \"ready\": true\n}");
            this.httpClient.Response = response;

            var charge = await this.openAIClient.RequestAsync<OpenAI.Engine>(
                HttpMethod.Post,
                "/v1/engines",
                this.options,
                this.requestOptions);

            Assert.NotNull(charge);
            Assert.Equal("text-davinci-003", charge.Id);
            Assert.Equal(response, charge.OpenAIResponse);
        }

        [Fact]
        public async Task RequestAsync_OkResponse_InvalidJson()
        {
            var response = new OpenAIResponse(HttpStatusCode.OK, null, "this isn't JSON");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<OpenAIException>(async () =>
                await this.openAIClient.RequestAsync<OpenAI.Engine>(
                    HttpMethod.Post,
                    "/v1/engines",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.OK, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"this isn't JSON\"", exception.Message);
            Assert.Equal(response, exception.OpenAIResponse);
        }

        [Fact]
        public async Task RequestAsync_Error_InvalidJson()
        {
            var response = new OpenAIResponse(
                HttpStatusCode.InternalServerError,
                null,
                "this isn't JSON");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<OpenAIException>(async () =>
                await this.openAIClient.RequestAsync<OpenAI.Engine>(
                    HttpMethod.Post,
                    "/v1/engines",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.InternalServerError, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"this isn't JSON\"", exception.Message);
            Assert.Equal(response, exception.OpenAIResponse);
        }

        [Fact]
        public async Task RequestAsync_Error_InvalidErrorObject()
        {
            var response = new OpenAIResponse(
                HttpStatusCode.InternalServerError,
                null,
                "{}");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<OpenAIException>(async () =>
                await this.openAIClient.RequestAsync<OpenAI.Engine>(
                    HttpMethod.Post,
                    "/v1/engines",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.InternalServerError, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"{}\"", exception.Message);
            Assert.Equal(response, exception.OpenAIResponse);
        }

        private static string StreamToString(Stream stream)
        {
            return new StreamReader(stream, Encoding.UTF8).ReadToEnd();
        }

        private class DummyHttpClient : IHttpClient
        {
            public OpenAIResponse Response { get; set; }

            public Task<OpenAIResponse> MakeRequestAsync(
                OpenAIRequest request)
            {
                if (this.Response == null)
                {
                    throw new OpenAITestException("Response is null");
                }

                return Task.FromResult<OpenAIResponse>(this.Response);
            }

            public Task<OpenAIResponse> MakeRequestAsync(
                OpenAIRequest request,
                CancellationToken cancellationToken = default)
            {
                if (this.Response == null)
                {
                    throw new OpenAITestException("Response is null");
                }

                return Task.FromResult<OpenAIResponse>(this.Response);
            }
        }
    }
}
