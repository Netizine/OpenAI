namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Given a prompt, the model will return one or more predicted completions, and can also return the probabilities of alternative tokens at each position.
    /// </summary>
    public class CompletionService : Service<Completion>,
        ICreatable<Completion, CompletionCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public CompletionService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public CompletionService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/completions";

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual Completion Create(CompletionCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<Completion> CreateAsync(CompletionCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }
    }
}
