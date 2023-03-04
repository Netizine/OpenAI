namespace OpenAI.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Moq.Protected;
    using OpenAI;

    public class MockHttpClientFixture
    {
        public MockHttpClientFixture()
        {
            MockHandler = new Mock<HttpClientHandler>
            {
                CallBase = true,
            };
            HttpClient = new SystemNetHttpClient(
                new HttpClient(MockHandler.Object));
        }

        public Mock<HttpClientHandler> MockHandler { get; }

        public SystemNetHttpClient HttpClient { get; }

        /// <summary>
        /// Resets the mock's state.
        /// </summary>
        public void Reset()
        {
            MockHandler.Reset();
        }

        /// <summary>
        /// Asserts that a single HTTP request was made with the specified method and path.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The HTTP path.</param>
        public void AssertRequest(HttpMethod method, string path)
        {
            MockHandler.Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(m =>
                        m.Method == method &&
                        m.RequestUri.AbsolutePath == path),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        /// Stubs an HTTP request with the specified method and path to return the specified status
        /// code and response body.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The HTTP path.</param>
        /// <param name="status">The status code to return.</param>
        /// <param name="response">The response body to return.</param>
        /// <param name="query">The HTTP query.</param>
        public void StubRequest(HttpMethod method, string path, HttpStatusCode status, string response, string query = null)
        {
            var responseMessage = new HttpResponseMessage(status);
            responseMessage.Content = new StringContent(response);

            MockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(m =>
                        (m.Method == method &&
                        m.RequestUri.AbsolutePath == path) &&
                        (query == null || m.RequestUri.Query == query)),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(responseMessage));
        }
    }
}
