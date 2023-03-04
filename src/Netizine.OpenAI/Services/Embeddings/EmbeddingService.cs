// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Creates an embedding vector representing the input text.
    /// </summary>
    public class EmbeddingService : Service<Embedding>,
        ICreatable<Embedding, EmbeddingCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddingService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public EmbeddingService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddingService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public EmbeddingService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/embeddings";

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="embeddingCreateOptions">The embedding create options.</param>
        /// <returns>The created entity.</returns>
        public Embedding Create(EmbeddingCreateOptions embeddingCreateOptions)
        {
            return Create(embeddingCreateOptions, null);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="embeddingCreateOptions">The embedding create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual Embedding Create(EmbeddingCreateOptions embeddingCreateOptions, RequestOptions requestOptions)
        {
            return CreateEntity(embeddingCreateOptions, requestOptions);
        }

        /// <summary>
        /// Creates a embedding result with the specified options asynchronously.
        /// </summary>
        /// <param name="embeddingCreateOptions">The embedding create options.</param>
        /// <returns>Task&lt;Embedding&gt;.</returns>
        public Task<Embedding> CreateAsync(EmbeddingCreateOptions embeddingCreateOptions)
        {
            return CreateAsync(embeddingCreateOptions, null, default);
        }

        /// <summary>
        /// Creates a embedding result with the specified options asynchronously.
        /// </summary>
        /// <param name="embeddingCreateOptions">The embedding create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Embedding&gt;.</returns>
        public Task<Embedding> CreateAsync(EmbeddingCreateOptions embeddingCreateOptions, CancellationToken cancellationToken)
        {
            return CreateAsync(embeddingCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Creates a embedding result with the specified options asynchronously.
        /// </summary>
        /// <param name="embeddingCreateOptions">The embedding create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Embedding&gt;.</returns>
        public Task<Embedding> CreateAsync(EmbeddingCreateOptions embeddingCreateOptions, RequestOptions requestOptions)
        {
            return CreateAsync(embeddingCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates a embedding result with the specified options asynchronously.
        /// </summary>
        /// <param name="embeddingCreateOptions">The embedding create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Embedding&gt;.</returns>
        public virtual Task<Embedding> CreateAsync(EmbeddingCreateOptions embeddingCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return CreateEntityAsync(embeddingCreateOptions, requestOptions, cancellationToken);
        }
    }
}
