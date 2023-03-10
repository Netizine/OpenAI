// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Infrastructure;

    /// <summary>
    /// A OpenAI client, used to issue requests to OpenAI's API and deserialize responses.
    /// </summary>
    public class OpenAIClient : IOpenAIClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="System.ArgumentException">API key cannot be the empty string. - apiKey</exception>
        /// <exception cref="System.ArgumentException">API key cannot contain whitespace. - apiKey</exception>
        public OpenAIClient(string apiKey)
        {
            if (apiKey is { Length: 0 })
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            OrganizationId = null;
            HttpClient = BuildDefaultHttpClient();
            ApiBase = DefaultApiBase;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <exception cref="System.ArgumentException">API key cannot be the empty string. - apiKey</exception>
        /// <exception cref="System.ArgumentException">API key cannot contain whitespace. - apiKey</exception>
        public OpenAIClient(string apiKey, IHttpClient httpClient)
        {
            if (apiKey is { Length: 0 })
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            OrganizationId = null;
            HttpClient = httpClient ?? BuildDefaultHttpClient();
            ApiBase = DefaultApiBase;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="apiBase">The API base.</param>
        /// <exception cref="System.ArgumentException">API key cannot be the empty string. - apiKey</exception>
        /// <exception cref="System.ArgumentException">API key cannot contain whitespace. - apiKey</exception>
        public OpenAIClient(string apiKey, IHttpClient httpClient, string apiBase)
        {
            if (apiKey is { Length: 0 })
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            OrganizationId = null;
            HttpClient = httpClient ?? BuildDefaultHttpClient();
            ApiBase = apiBase ?? DefaultApiBase;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="organizationId">The organization identifier.</param>
        /// <exception cref="System.ArgumentException">API key cannot be the empty string. - apiKey</exception>
        /// <exception cref="System.ArgumentException">API key cannot contain whitespace. - apiKey</exception>
        public OpenAIClient(string apiKey, string organizationId)
        {
            if (apiKey is { Length: 0 })
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            OrganizationId = organizationId;
            HttpClient = BuildDefaultHttpClient();
            ApiBase = DefaultApiBase;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="organizationId">The organization identifier.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <exception cref="System.ArgumentException">API key cannot be the empty string. - apiKey</exception>
        /// <exception cref="System.ArgumentException">API key cannot contain whitespace. - apiKey</exception>
        public OpenAIClient(string apiKey, string organizationId, IHttpClient httpClient)
        {
            if (apiKey is { Length: 0 })
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            OrganizationId = organizationId;
            HttpClient = httpClient ?? BuildDefaultHttpClient();
            ApiBase = DefaultApiBase;
        }

        /// <summary>Initializes a new instance of the <see cref="OpenAIClient"/> class.</summary>
        /// <param name="apiKey">The API key used by the client to make requests.</param>
        /// <param name="organizationId">The organization ID used by the client.</param>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <param name="apiBase">
        /// The base URL for OpenAI's API. Defaults to <see cref="DefaultApiBase"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">if <c>apiKey</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// if <c>apiKey</c> is empty or contains whitespace.
        /// </exception>
        public OpenAIClient(string apiKey, string organizationId, IHttpClient httpClient, string apiBase)
        {
            if (apiKey is { Length: 0 })
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            ApiKey = apiKey;
            OrganizationId = organizationId;
            HttpClient = httpClient ?? BuildDefaultHttpClient();
            ApiBase = apiBase ?? DefaultApiBase;
        }

        /// <summary>Default base URL for OpenAI's API.</summary>
        public static string DefaultApiBase => "https://api.openai.com";

        /// <summary>Gets the base URL for OpenAI's API.</summary>
        /// <value>The base URL for OpenAI's API.</value>
        public string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        public string ApiKey { get; }

        /// <summary>Gets the client ID used by the client in OAuth requests.</summary>
        /// <value>The client ID used by the client in OAuth requests.</value>
        public string OrganizationId { get; }

        /// <summary>Gets the <see cref="IHttpClient"/> used to send HTTP requests.</summary>
        /// <value>The <see cref="IHttpClient"/> used to send HTTP requests.</value>
        public IHttpClient HttpClient { get; }

        /// <summary>Sends a request to OpenAI's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the OpenAI entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="OpenAIException">Thrown if the request fails.</exception>
        public Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
            where T : IOpenAIEntity
        {
            return RequestAsync<T>(method, path, options, requestOptions, default);
        }

        /// <summary>Sends a request to OpenAI's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the OpenAI entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="OpenAIException">Thrown if the request fails.</exception>
        public async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
            where T : IOpenAIEntity
        {
            var request = new OpenAIRequest(this, method, path, options, requestOptions);

            var response = await HttpClient.MakeRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            if (request.Method == HttpMethod.Get && request.Uri.AbsoluteUri.Contains("/v1/files/") && request.Uri.AbsoluteUri.EndsWith("/content"))
            {
                return (T)(IOpenAIEntity)new FileContent
                {
                    Content = response.Content,
                };
            }

            return ProcessResponse<T>(response);
        }

        private static IHttpClient BuildDefaultHttpClient()
        {
            return new SystemNetHttpClient(OpenAIConfiguration.MaxNetworkRetries);
        }

        private static T ProcessResponse<T>(OpenAIResponse response)
            where T : IOpenAIEntity
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw BuildOpenAIException(response);
            }

            T obj;
            try
            {
                obj = OpenAIEntity.FromJson<T>(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                throw BuildInvalidResponseException(response);
            }

            obj.OpenAIResponse = response;

            return obj;
        }

        private static OpenAIException BuildOpenAIException(OpenAIResponse response)
        {
            JObject jObject;

            try
            {
                jObject = JObject.Parse(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                return BuildInvalidResponseException(response);
            }

            // If the value of the `error` key is a string, then the error is an OAuth error
            // and we instantiate the OpenAIError object with the entire JSON.
            // Otherwise, it's a regular API error and we instantiate the OpenAIError object
            // with just the nested hash contained in the `error` key.
            var errorToken = jObject["error"];
            if (errorToken == null)
            {
                return BuildInvalidResponseException(response);
            }

            var openAIError = errorToken.Type == JTokenType.String
                ? OpenAIError.FromJson(response.Content)
                : OpenAIError.FromJson(errorToken.ToString());

            openAIError.OpenAIResponse = response;

            return new OpenAIException(
                response.StatusCode,
                openAIError,
                openAIError.Message)
            {
                OpenAIResponse = response,
            };
        }

        private static OpenAIException BuildInvalidResponseException(OpenAIResponse response)
        {
            return new OpenAIException(
                response.StatusCode,
                null,
                $"Invalid response object from API: \"{response.Content}\"")
            {
                OpenAIResponse = response,
            };
        }
    }
}
