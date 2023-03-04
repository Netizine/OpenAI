using Newtonsoft.Json.Linq;

namespace OpenAI.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using OpenAI;

    public class OpenAIMockFixture : IDisposable
    {
        /// <value>Minimum required version of openai-mock.</value>
        private const string MockMinimumVersion = "1.0.8.0";

        private readonly string port;

        public OpenAIMockFixture()
        {
            if (OpenAIMockHandler.StartOpenAIMock())
            {
                port = OpenAIMockHandler.Port.ToString();
            }
            else
            {
                port = Environment.GetEnvironmentVariable("OPENAI_MOCK_PORT") ?? "8020";
            }

            EnsureOpenAIMockMinimumVersion();
        }

        public void Dispose()
        {
            OpenAIMockHandler.StopOpenAIMock();
        }

        /// <summary>
        /// Creates and returns a new instance of <see cref="OpenAIClient"/> suitable for use with
        /// openai-mock.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <returns>The new <see cref="OpenAIClient"/> instance.</returns>
        public OpenAIClient BuildOpenAIClient(IHttpClient httpClient = null)
        {
            return new OpenAIClient(
                "sk-test",
                "org_123",
                httpClient: httpClient,
                apiBase: $"http://localhost:{port}");
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
        public string GetFixture(string path, string[] expansions = null)
        {
            string url = $"http://localhost:{port}{path}";

            if (expansions != null)
            {
                string query = string.Join("&", expansions.Select(x => $"expand[]={x}").ToArray());
                url += $"?{query}";
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        "sk-test");

                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new OpenAITestException(
                        $"Couldn't reach openai-mock at `localhost:{port}`. "
                        + "Is it running? Please see README for setup instructions.");
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new OpenAITestException(
                        $"openai-mock returned status code: {response.StatusCode}.");
                }

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Compares two version strings.
        /// </summary>
        /// <param name="a">A version string (e.g. "1.2.3").</param>
        /// <param name="b">Another version string.</param>
        /// <returns>-1 if a &gt; b, 1 if a &lt; b, 0 if a == b.</returns>
        private static int CompareVersions(string a, string b)
        {
            var version1 = new Version(a);
            var version2 = new Version(b);
            return version2.CompareTo(version1);
        }

        private void EnsureOpenAIMockMinimumVersion()
        {
            string url = $"http://localhost:{port}/v1/version";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new OpenAITestException(
                        $"Couldn't reach openai-mock at `localhost:{port}`. "
                        + "Is it running? Please see README for setup instructions.");
                }

                string json = response.Content.ReadAsStringAsync().Result;

                //string version = System.Text.Json.JsonDocument.Parse(json).RootElement.GetProperty("version").GetString();
                dynamic d = JObject.Parse(json);

                string version = ((JValue)d.version).Value.ToString();

                if (!version.Equals(MockMinimumVersion))
                {
                    throw new OpenAITestException(
                        $"openai-mock version {version} is not supported. "
                        + $"Please upgrade to at least version {MockMinimumVersion}.");
                }
            }
        }
    }
}
