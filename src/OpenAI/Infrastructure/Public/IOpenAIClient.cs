// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for a OpenAI client.
    /// </summary>
    public interface IOpenAIClient
    {
        /// <summary>Gets the base URL for OpenAI's API.</summary>
        /// <value>The base URL for OpenAI's API.</value>
        string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        string ApiKey { get; }

        /// <summary>Gets the Organization ID used by the client.</summary>
        /// <value>The Organization ID used by the client.</value>
        string OrganizationId { get; }

        /// <summary>Sends a request to OpenAI's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the OpenAI entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="OpenAIException">Thrown if the request fails.</exception>
        Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
            where T : IOpenAIEntity;
    }
}
