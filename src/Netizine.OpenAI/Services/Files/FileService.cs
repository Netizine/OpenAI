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
        /// Gets the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>File.</returns>
        public virtual File Get(string id)
        {
            return this.Get(id, null, null);
        }

        /// <summary>
        /// Gets the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileGetOptions">The file get options.</param>
        /// <returns>File.</returns>
        public virtual File Get(string id, FileGetOptions fileGetOptions)
        {
            return this.Get(id, fileGetOptions, null);
        }

        /// <summary>
        /// Gets the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>File.</returns>
        public virtual File Get(string id, RequestOptions requestOptions)
        {
            return this.Get(id, null, requestOptions);
        }

        /// <summary>
        /// Gets the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileGetOptions">The file get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>File.</returns>
        public virtual File Get(string id, FileGetOptions fileGetOptions, RequestOptions requestOptions)
        {
            return this.GetEntity(id, fileGetOptions, requestOptions);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id)
        {
            return this.GetAsync(id, null, null, default);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileGetOptions">The file get options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, FileGetOptions fileGetOptions)
        {
            return this.GetAsync(id, fileGetOptions, null, default);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileGetOptions">The file get options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, FileGetOptions fileGetOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, fileGetOptions, null, cancellationToken);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, RequestOptions requestOptions)
        {
            return this.GetAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileGetOptions">The file get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> GetAsync(string id, FileGetOptions fileGetOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetEntityAsync(id, fileGetOptions, requestOptions, cancellationToken);
        }

        public virtual OpenAIList<File> List()
        {
            return this.List(null, null);
        }

        public virtual OpenAIList<File> List(FileListOptions fileListOptions)
        {
            return this.List(fileListOptions, null);
        }

        public virtual OpenAIList<File> List(RequestOptions requestOptions)
        {
            return this.List(null, requestOptions);
        }

        /// <summary>
        /// Lists the specified options.
        /// </summary>
        /// <param name="fileListOptions">The file list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;File&gt;.</returns>
        public virtual OpenAIList<File> List(FileListOptions fileListOptions, RequestOptions requestOptions)
        {
            return this.ListEntities(fileListOptions, requestOptions);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync()
        {
            return this.ListAsync(null, null, default);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(CancellationToken cancellationToken)
        {
            return this.ListAsync(null, null, cancellationToken);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="fileListOptions">The file list options.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(FileListOptions fileListOptions)
        {
            return this.ListAsync(fileListOptions, null, default);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="fileListOptions">The file list options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(FileListOptions fileListOptions, CancellationToken cancellationToken)
        {
            return this.ListAsync(fileListOptions, null, cancellationToken);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(RequestOptions requestOptions)
        {
            return this.ListAsync(null, requestOptions, default);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.ListAsync(null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="fileListOptions">The file list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(FileListOptions fileListOptions, RequestOptions requestOptions)
        {
            return this.ListAsync(fileListOptions, requestOptions, default);
        }

        /// <summary>
        /// Lists the files by the specified options asynchronously.
        /// </summary>
        /// <param name="fileListOptions">The file list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;File&gt;&gt;.</returns>
        public virtual Task<OpenAIList<File>> ListAsync(FileListOptions fileListOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.ListEntitiesAsync(fileListOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="createOptions">The create options.</param>
        /// <returns>The created entity.</returns>
        public File Create(FileCreateOptions createOptions)
        {
            return this.Create(createOptions, null);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="createOptions">The create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual File Create(FileCreateOptions createOptions, RequestOptions requestOptions)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fileCreateOptions">The file create options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> CreateAsync(FileCreateOptions fileCreateOptions)
        {
            return this.CreateAsync(fileCreateOptions, null, default);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fileCreateOptions">The file create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> CreateAsync(FileCreateOptions fileCreateOptions, CancellationToken cancellationToken)
        {
            return this.CreateAsync(fileCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fileCreateOptions">The file create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> CreateAsync(FileCreateOptions fileCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateAsync(fileCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fileCreateOptions">The file create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> CreateAsync(FileCreateOptions fileCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.CreateEntityAsync(fileCreateOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Deletes the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>File.</returns>
        public File Delete(string id)
        {
            return this.DeleteEntity(id, null, null);
        }

        /// <summary>
        /// Deletes the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileDeleteOptions">The file delete options.</param>
        /// <returns>File.</returns>
        public File Delete(string id, FileDeleteOptions fileDeleteOptions)
        {
            return this.DeleteEntity(id, fileDeleteOptions, null);
        }

        /// <summary>
        /// Deletes the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>File.</returns>
        public File Delete(string id, RequestOptions requestOptions)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        /// <summary>
        /// Deletes the file by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileDeleteOptions">The file delete options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>File.</returns>
        public virtual File Delete(string id, FileDeleteOptions fileDeleteOptions, RequestOptions requestOptions)
        {
            return this.DeleteEntity(id, fileDeleteOptions, requestOptions);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id)
        {
            return this.DeleteAsync(id, null, null, default);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            return this.DeleteAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileDeleteOptions">The file delete options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id, FileDeleteOptions fileDeleteOptions)
        {
            return this.DeleteAsync(id, fileDeleteOptions, null, default);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileDeleteOptions">The file delete options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id, FileDeleteOptions fileDeleteOptions, CancellationToken cancellationToken)
        {
            return this.DeleteAsync(id, fileDeleteOptions, null, cancellationToken);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id, RequestOptions requestOptions)
        {
            return this.DeleteAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.DeleteAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileDeleteOptions">The file delete options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public Task<File> DeleteAsync(string id, FileDeleteOptions fileDeleteOptions, RequestOptions requestOptions)
        {
            return this.DeleteAsync(id, fileDeleteOptions, requestOptions, default);
        }

        /// <summary>
        /// Deletes the file by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fileDeleteOptions">The file delete options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;File&gt;.</returns>
        public virtual Task<File> DeleteAsync(string id, FileDeleteOptions fileDeleteOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.DeleteEntityAsync(id, fileDeleteOptions, requestOptions, cancellationToken);
        }
    }
}