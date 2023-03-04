// ReSharper disable once CheckNamespace
namespace OpenAI
{
    /// <summary>
    /// The HTTP request options.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Gets or sets the <a href="https://beta.openai.com/docs/api-reference/authentication">API
        /// key</a> to use for the request.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Get or sets the
        /// <a href="https://beta.openai.com/account/org-settings">Organization Id
        /// of the connected account</a> to use for the request.
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>Gets or sets the base URL for the request.</summary>
        /// <remarks>
        /// This is an internal property. It is set by services or individual request methods.
        /// </remarks>
        internal string BaseUrl { get; set; }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>The cloned instance.</returns>
        internal RequestOptions Clone()
        {
            return (RequestOptions)this.MemberwiseClone();
        }
    }
}
