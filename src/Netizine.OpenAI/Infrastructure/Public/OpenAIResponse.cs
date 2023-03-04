// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Net;
    using System.Net.Http.Headers;

    /// <summary>
    /// Represents a buffered textual response from OpenAI's API.
    /// </summary>
    public class OpenAIResponse : OpenAIResponseBase
    {
        /// <summary>Initializes a new instance of the <see cref="OpenAIResponse"/> class.</summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers of the response.</param>
        /// <param name="content">The body of the response.</param>
        public OpenAIResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
            : base(statusCode, headers)
        {
            Content = content;
        }

        /// <summary>Gets the body of the response.</summary>
        /// <value>The body of the response.</value>
        public string Content { get; }
    }
}
