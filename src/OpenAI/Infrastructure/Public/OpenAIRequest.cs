// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using OpenAI.Infrastructure.FormEncoding;

    /// <summary>
    /// Represents a request to OpenAI's API.
    /// </summary>
    public class OpenAIRequest
    {
        private readonly BaseOptions options;

        /// <summary>Initializes a new instance of the <see cref="OpenAIRequest"/> class.</summary>
        /// <param name="client">The client creating the request.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        public OpenAIRequest(
            IOpenAIClient client,
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.options = options;

            this.Method = method;

            this.Uri = BuildUri(client, method, path, options, requestOptions);

            this.AuthorizationHeader = BuildAuthorizationHeader(client, requestOptions);

            this.OpenAIHeaders = BuildOpenAIHeaders(requestOptions);
        }

        /// <summary>The HTTP method for the request (GET, POST or DELETE).</summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// The URL for the request. If this is a GET or DELETE request, the URL also includes
        /// the request parameters in its query string.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>The value of the <c>Authorization</c> header with the API key.</summary>
        public AuthenticationHeaderValue AuthorizationHeader { get; }

        /// <summary>
        /// Dictionary containing OpenAI custom headers (<c>OpenAI-Organization</c>...).
        /// </summary>
        public IDictionary<string, string> OpenAIHeaders { get; }

        /// <summary>
        /// The body of the request. For POST requests, this will be either a
        /// <c>application/x-www-form-urlencoded</c>, <c>multipart/form-data</c> or a <c>application/json</c> payload.
        /// For non-POST requests, this will be <c>null</c>.
        /// </summary>
        /// <remarks>This getter creates a new instance every time it is called.</remarks>
        public HttpContent Content => BuildContent(this.Method, this.options);

        /// <summary>Returns a string that represents the <see cref="OpenAIRequest"/>.</summary>
        /// <returns>A string that represents the <see cref="OpenAIRequest"/>.</returns>
        public override string ToString()
        {
            return $"<{this.GetType().FullName} Method={this.Method} Uri={this.Uri}>";
        }

        private static Uri BuildUri(
            IOpenAIClient client,
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            var b = new StringBuilder();

            b.Append(requestOptions?.BaseUrl ?? client.ApiBase);
            b.Append(path);

            // ReSharper disable once InvertIf
            if ((method != HttpMethod.Post) && (options != null))
            {
                var queryString = FormEncoder.CreateQueryString(options);

                // ReSharper disable once InvertIf
                if (!string.IsNullOrEmpty(queryString))
                {
                    b.Append("?");
                    b.Append(queryString);
                }
            }

            return new Uri(b.ToString());
        }

        private static AuthenticationHeaderValue BuildAuthorizationHeader(
            IOpenAIClient client,
            RequestOptions requestOptions)
        {
            string apiKey = requestOptions?.ApiKey ?? client.ApiKey;

            if (apiKey == null)
            {
                const string message = "No API key provided. Set your API key using "
                                       + "`OpenAIConfiguration.ApiKey = \"<API-KEY>\"`. You can generate API keys "
                                       + "from the OpenAI Dashboard. See "
                                       + "https://beta.openai.com/docs/api-reference/authentication for details.";
                throw new OpenAIException(message);
            }

            return new AuthenticationHeaderValue("Bearer", apiKey);
        }

        private static Dictionary<string, string> BuildOpenAIHeaders(RequestOptions requestOptions)
        {
            var openAIHeaders = new Dictionary<string, string>();
            if (requestOptions != null)
            {
                if (!string.IsNullOrEmpty(requestOptions.OrganizationId))
                {
                    openAIHeaders.Add("OpenAI-Organization", requestOptions.OrganizationId);
                }
            }

            return openAIHeaders;
        }

        private static HttpContent BuildContent(HttpMethod method, BaseOptions options)
        {
            return method != HttpMethod.Post ? null : FormEncoder.CreateHttpContent(options);
        }
    }
}
