// ReSharper disable once CheckNamespace
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
        /// <param name="completionCreateOptions">The completion create options.</param>
        /// <returns>The created entity.</returns>
        public virtual Completion Create(CompletionCreateOptions completionCreateOptions)
        {
            return Create(completionCreateOptions, null);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="completionCreateOptions">The completion create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual Completion Create(CompletionCreateOptions completionCreateOptions, RequestOptions requestOptions)
        {
            return CreateEntity(completionCreateOptions, requestOptions);
        }

        /// <summary>
        /// Creates a completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="completionCreateOptions">The completion create options.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<Completion> CreateAsync(CompletionCreateOptions completionCreateOptions)
        {
            return CreateAsync(completionCreateOptions, null, default);
        }

        /// <summary>
        /// Creates a completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="completionCreateOptions">The completion create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<Completion> CreateAsync(CompletionCreateOptions completionCreateOptions, CancellationToken cancellationToken)
        {
            return CreateAsync(completionCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Creates a completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="completionCreateOptions">The completion create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<Completion> CreateAsync(CompletionCreateOptions completionCreateOptions, RequestOptions requestOptions)
        {
            return CreateAsync(completionCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates a completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="completionCreateOptions">The completion create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<Completion> CreateAsync(CompletionCreateOptions completionCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return CreateEntityAsync(completionCreateOptions, requestOptions, cancellationToken);
        }
    }
}
