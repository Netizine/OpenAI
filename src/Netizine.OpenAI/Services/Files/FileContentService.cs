// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// Class FileContentService.
    /// Implements the <see cref="OpenAI.Service{OpenAI.FileContent}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.FileContent}" />
    public class FileContentService : Service<FileContent>
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileContentService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public FileContentService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileContentService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public FileContentService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => null;

        /// <summary>
        /// Gets the file content by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>FileContent.</returns>
        public virtual FileContent Get(string id)
        {
            return Get(id, null);
        }

        /// <summary>
        /// Gets the file content by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FileContent.</returns>
        public virtual FileContent Get(string id, RequestOptions requestOptions)
        {
            return Request(HttpMethod.Get, $"/v1/files/{id}/content", null, requestOptions);
        }

        /// <summary>
        /// Gets the file content by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;FileContent&gt;.</returns>
        public virtual Task<FileContent> GetAsync(string id)
        {
            return GetAsync(id, null, default);
        }

        /// <summary>
        /// Gets the file content by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FileContent&gt;.</returns>
        public virtual Task<FileContent> GetAsync(string id, CancellationToken cancellationToken)
        {
            return GetAsync(id, null, cancellationToken);
        }

        /// <summary>
        /// Gets the file content by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FileContent&gt;.</returns>
        public virtual Task<FileContent> GetAsync(string id, RequestOptions requestOptions)
        {
            return GetAsync(id, requestOptions, default);
        }

        /// <summary>
        /// Gets the file content by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FileContent&gt;.</returns>
        public virtual Task<FileContent> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return RequestAsync(HttpMethod.Get, $"/v1/files/{id}/content", null, requestOptions, cancellationToken);
        }
    }
}
