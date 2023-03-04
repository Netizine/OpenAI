// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http.Headers;

    /// <summary>
    /// Represents a response from OpenAI's API.
    /// </summary>
    public abstract class OpenAIResponseBase
    {
        /// <summary>Initializes a new instance of the <see cref="OpenAIResponseBase"/> class.</summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers of the response.</param>
        protected OpenAIResponseBase(HttpStatusCode statusCode, HttpResponseHeaders headers)
        {
            StatusCode = statusCode;
            Headers = headers;
        }

        /// <summary>Gets the HTTP status code of the response.</summary>
        /// <value>The HTTP status code of the response.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>Gets the HTTP headers of the response.</summary>
        /// <value>The HTTP headers of the response.</value>
        public HttpResponseHeaders Headers { get; }

        /// <summary>Gets the date of the request, as returned by OpenAI.</summary>
        /// <value>The date of the request, as returned by OpenAI.</value>
        public DateTimeOffset? Date => Headers?.Date;

        /// <summary>Gets the organization id key of the request, as returned by OpenAI.</summary>
        /// <value>The organization id key of the request, as returned by OpenAI.</value>
        public string OrganizationId => MaybeGetHeader(Headers, "OpenAI-Organization");

        /// <summary>Gets the ID of the request, as returned by OpenAI.</summary>
        /// <value>The ID of the request, as returned by OpenAI.</value>
        public string RequestId => MaybeGetHeader(Headers, "Request-Id");

        internal int NumRetries { get; set; }

        /// <summary>Returns a string that represents the <see cref="OpenAIResponse"/>.</summary>
        /// <returns>A string that represents the <see cref="OpenAIResponse"/>.</returns>
        public override string ToString()
        {
            return
                $"<{GetType().FullName} status={(int)StatusCode} Request-Id={RequestId} Date={Date?.ToString("s")}>";
        }

        private static string MaybeGetHeader(HttpHeaders headers, string name)
        {
            if ((headers == null) || (!headers.Contains(name)))
            {
                return null;
            }

            return headers.GetValues(name).First();
        }
    }
}
