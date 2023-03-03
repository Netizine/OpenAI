// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Net;

    /// <summary>
    /// The OpenAI exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class OpenAIException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIException"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public OpenAIException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OpenAIException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="err">The error.</param>
        // ReSharper disable once UnusedMember.Global
        public OpenAIException(string message, Exception err)
            : base(message, err)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIException"/> class.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="openAIError">The OpenAI error.</param>
        /// <param name="message">The message.</param>
        public OpenAIException(HttpStatusCode httpStatusCode, OpenAIError openAIError, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.OpenAIError = openAIError;
        }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the OpenAI error.
        /// </summary>
        public OpenAIError OpenAIError { get; set; }

        /// <summary>
        /// Gets or sets the OpenAI response.
        /// </summary>
        public OpenAIResponse OpenAIResponse { get; set; }
    }
}
