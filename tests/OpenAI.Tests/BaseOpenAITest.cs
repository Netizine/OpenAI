namespace OpenAI.Tests
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using OpenAI;
    using Xunit;

    [Collection("openai-mock tests")]
    public class BaseOpenAITest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOpenAITest"/> class with no fixtures.
        /// </summary>
        public BaseOpenAITest()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOpenAITest"/> class with the
        /// <see cref="OpenAIMockFixture"/> fixture. Use this constructor for tests that need to
        /// send requests to openai-mock, but don't need mocking capabilities (i.e. don't need to
        /// assert or stub HTTP requests).
        /// </summary>
        /// <param name="openAIMockFixture">
        /// The <see cref="OpenAIMockFixture"/> fixture.
        /// </param>
        public BaseOpenAITest(OpenAIMockFixture openAIMockFixture)
            : this(openAIMockFixture, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOpenAITest"/> class with the
        /// <see cref="MockHttpClientFixture"/> fixture. Use this constructor for tests that need
        /// mocking capabilities (i.e. need to assert or stub HTTP requests) but don't need to send
        /// requests to openai-mock.
        /// </summary>
        /// <param name="mockHttpClientFixture">
        /// The <see cref="MockHttpClientFixture"/> fixture.
        /// </param>
        public BaseOpenAITest(MockHttpClientFixture mockHttpClientFixture)
            : this(null, mockHttpClientFixture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOpenAITest"/> class with both the
        /// <see cref="OpenAIMockFixture"/> and the <see cref="MockHttpClientFixture"/> fixtures.
        /// Use this constructor for tests that need to send requests to openai-mock and also need
        /// mocking capabilities (i.e. need to assert or stub HTTP requests).
        /// </summary>
        /// <param name="openAIMockFixture">
        /// The <see cref="OpenAIMockFixture"/> fixture.
        /// </param>
        /// <param name="mockHttpClientFixture">
        /// The <see cref="MockHttpClientFixture"/> fixture.
        /// </param>
        public BaseOpenAITest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
        {
            this.OpenAIMockFixture = openAIMockFixture;
            this.MockHttpClientFixture = mockHttpClientFixture;

            if ((this.OpenAIMockFixture != null) && (this.MockHttpClientFixture != null))
            {
                // Set up OpenAIClient to use openai-mock with the mock HTTP client
                var httpClient = new SystemNetHttpClient(
                    new HttpClient(this.MockHttpClientFixture.MockHandler.Object));
                this.OpenAIClient = this.OpenAIMockFixture.BuildOpenAIClient(
                    httpClient: httpClient);

                // Reset the mock before each test
                this.MockHttpClientFixture.Reset();
            }
            else if (this.OpenAIMockFixture != null)
            {
                // Set up OpenAIClient to use openai-mock
                this.OpenAIClient = this.OpenAIMockFixture.BuildOpenAIClient();
            }
            else if (this.MockHttpClientFixture != null)
            {
                // Set up OpenAIClient with the mock HTTP client
                var httpClient = new SystemNetHttpClient(
                    new HttpClient(this.MockHttpClientFixture.MockHandler.Object));
                this.OpenAIClient = new OpenAIClient(
                    "sk-test",
                    httpClient: httpClient);

                // Reset the mock before each test
                this.MockHttpClientFixture.Reset();
            }
            else
            {
                // Use the default OpenAIClient
                this.OpenAIClient = new OpenAIClient("sk-test");
            }
        }

        protected IOpenAIClient OpenAIClient { get; }

        protected MockHttpClientFixture MockHttpClientFixture { get; }

        protected OpenAIMockFixture OpenAIMockFixture { get; }

        /// <summary>
        /// Gets a resource file and returns its contents in a string.
        /// </summary>
        /// <param name="path">Path to the resource file.</param>
        /// <returns>The file contents.</returns>
        protected static string GetResourceAsString(string path)
        {
            var fullpath = "OpenAI.Tests.Resources." + path;
            var contents = new StreamReader(
                typeof(BaseOpenAITest).GetTypeInfo().Assembly.GetManifestResourceStream(fullpath),
                Encoding.UTF8).ReadToEnd();

            return contents;
        }

        /// <summary>
        /// Asserts that a single HTTP request was made with the specified method and path.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The HTTP path.</param>
        protected void AssertRequest(HttpMethod method, string path)
        {
            if (this.MockHttpClientFixture == null)
            {
                throw new OpenAITestException(
                    "AssertRequest called from a test class that doesn't have access to "
                    + "MockHttpClientFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives MockHttpClientFixture and calls the "
                    + "base constructor.");
            }

            this.MockHttpClientFixture.AssertRequest(method, path);
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
        protected void StubRequest(HttpMethod method, string path, HttpStatusCode status, string response, string query = null)
        {
            if (this.MockHttpClientFixture == null)
            {
                throw new OpenAITestException(
                    "StubRequest called from a test class that doesn't have access to "
                    + "MockHttpClientFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives MockHttpClientFixture and calls the "
                    + "base constructor.");
            }

            this.MockHttpClientFixture.StubRequest(method, path, status, response, query);
        }

        /// <summary>
        /// Gets fixture data with expansions specified. Expansions are specified the same way as
        /// they are in the normal API like <c>customer</c> or <c>data.customer</c>.
        /// Use the special <c>*</c> character to specify that all fields should be
        /// expanded.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for openai-mock.</param>
        /// <param name="expansions">Set of expansions that should be applied.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        protected string GetFixture(string path, string[] expansions = null)
        {
            if (this.OpenAIMockFixture == null)
            {
                throw new OpenAITestException(
                    "GetFixture called from a test class that doesn't have access to "
                    + "OpenAIMockFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives OpenAIMockFixture and calls the "
                    + "base constructor.");
            }

            return this.OpenAIMockFixture.GetFixture(path, expansions);
        }
    }
}
