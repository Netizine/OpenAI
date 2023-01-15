namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// Files are used to upload documents that can be used with features like <see href="https://beta.openai.com/docs/api-reference/fine-tunes">Fine-tuning</see>Fine-tuning.
    /// Implements the <see cref="OpenAI.Service{OpenAI.File}" />.
    /// Implements the <see cref="OpenAI.IListable{OpenAI.File, OpenAI.FileListOptions}" />.
    /// Implements the <see cref="OpenAI.IRetrievable{OpenAI.File, OpenAI.FileGetOptions}" />.
    /// Implements the <see cref="OpenAI.ICreatable{OpenAI.File, OpenAI.FileCreateOptions}" />.
    /// Implements the <see cref="OpenAI.IDeletable{OpenAI.File, OpenAI.FileDeleteOptions}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.File}" />
    /// <seealso cref="OpenAI.IListable{OpenAI.File, OpenAI.FileListOptions}" />
    /// <seealso cref="OpenAI.IRetrievable{OpenAI.File, OpenAI.FileGetOptions}" />
    /// <seealso cref="OpenAI.ICreatable{OpenAI.File, OpenAI.FileCreateOptions}" />
    /// <seealso cref="OpenAI.IDeletable{OpenAI.File, OpenAI.FileDeleteOptions}" />
    public class FileService : Service<File>,
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
        IListable<File, FileListOptions>,
        IRetrievable<File, FileGetOptions>,
        ICreatable<File, FileCreateOptions>,
        IDeletable<File, FileDeleteOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public FileService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public FileService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/files";

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        public virtual File Get(string id, FileGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, FileGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;File&gt;.</returns>
        public virtual OpenAIList<File> List(FileListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Lists the specified options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(FileListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual File Create(FileCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> CreateAsync(FileCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity.</returns>
        public virtual File Delete(string id, FileDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, options, requestOptions);
        }

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted entity task.</returns>
        public virtual Task<File> DeleteAsync(string id, FileDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.DeleteEntityAsync(id, options, requestOptions, cancellationToken);
        }
    }
}